using Generic.DataAccess;
using Generic.Log;
using RyanLiu.CodingTask.Core.Contracts;
using RyanLiu.CodingTask.Models;
using RyanLiu.CodingTask.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RyanLiu.CodingTask.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IInputFilesGenerator _fileGenerator;
        
        public HomeController(IInputFilesGenerator fileGenerator)
        {
            this._fileGenerator = fileGenerator;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var vm = new InputsViewModel();
            var dataRepository = DataRepositoryTool.GetDataRepository();
            var regions = await dataRepository.GetListAsync<Region>();
            var products = await dataRepository.GetListAsync<Product>();
            var channels = await dataRepository.GetListAsync<Channel>();            
            vm.Regions = from r in regions select new SelectableRegion() { Entity = r };
            vm.Products = from p in products select new SelectableProduct() { Entity = p };
            vm.Chanlels = from c in channels select new SelectableChannel() { Entity = c };                        
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(InputsViewModel inputs)
        {
            if (this.ModelState.IsValid)
            {
                //save inputs
                //Another simpler way is to generate input files without save inputs first
                //But by saving to db first, later easy to improve it to make it more user friendly and scalaable.  
                var runInstance = await SaveInputsAsync(inputs);

                //generate input files
                await _fileGenerator.GenerateInputFilesAsync(runInstance.run_instance_id);
                           
                //redirect
                return RedirectToAction("Index", "RunScripts", new { runInstanceId = runInstance.run_instance_id });
            }
            else
            {
                return View(inputs);
            }
        }

      

        public ActionResult Readme()
        {
            return File("~/Readme.html", "text/html");
          
        }

        public ActionResult Contact()
        {
            return View();
        }

        private async Task<RunInstance> SaveInputsAsync(InputsViewModel inputs)
        {
            var runInstance = new RunInstance()
            {
                Setup = inputs.Setup.ToModel()
            };
            foreach (var region in inputs.Regions.Where(r => r.Selected == true))
            {
                runInstance.RunInstance_Region.Add(
                    new RunInstance_Region() { region_code = region.Entity.region_code });
            }

            foreach (var region in inputs.Products.Where(p => p.Selected == true))
            {
                runInstance.RunInstance_Product.Add(
                    new RunInstance_Product() { product_code = region.Entity.product_code });
            }

            foreach (var channel in inputs.Chanlels.Where(c => c.Selected == true))
            {
                runInstance.RunInstance_Channel.Add(
                    new RunInstance_Channel() { channel_code = channel.Entity.channel_code });
            }

            var dataRepository = DataRepositoryTool.GetDataRepository();

            await dataRepository.AddAsync(runInstance);
            return runInstance;
        }

    }
}