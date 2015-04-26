using RyanLiu.CodingTask.Core.Contracts;
using RyanLiu.CodingTask.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RyanLiu.CodingTask.Web.Controllers
{
    public class RunScriptsController : Controller
    {
        private readonly IContentStorage _contentStorage;
        private readonly IOutputsSaver _outputsSaver;
        public RunScriptsController(IContentStorage contentStorage, IOutputsSaver outputsSaver)
        {
            _contentStorage = contentStorage;
            _outputsSaver = outputsSaver;
        }

        [HttpGet]
        public ActionResult Index(int runInstanceId)
        {
            RunScriptsViewModel vm = new RunScriptsViewModel()
            {
                RunInstanceId = runInstanceId,
                Path = _contentStorage.GetRunInstanceDirectory(runInstanceId)
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveOutputs(int runInstanceId)
        {
            _outputsSaver.SaveOutputs(runInstanceId);
            return View();
        }
    }
}