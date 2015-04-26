using CsvHelper;
using CsvHelper.Configuration;
using Generic.DataAccess;
using RyanLiu.CodingTask.Core.Contracts;
using RyanLiu.CodingTask.Core.Models.CsvMapps;
using RyanLiu.CodingTask.Core.Models.Outputs;
using RyanLiu.CodingTask.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanLiu.CodingTask.Core
{
    /// <summary>
    /// save output files into db
    /// </summary>
    public class OutputsDatabaseSaver : IOutputsSaver
    {
        private readonly IContentStorage _contentStorage;
        private readonly IDataRepository _dataRepository;

        public OutputsDatabaseSaver(IContentStorage contentStorage, IDataRepository dataRepository)
        {
            this._contentStorage = contentStorage;
            this._dataRepository = dataRepository;
        }

        public void SaveOutputs(int runInstanceId)
        {
            SaveOutputProducts(runInstanceId);

            //similar thing should be done to other tables ..
        }

        private void SaveOutputProducts(int runInstanceId)
        {
            IEnumerable<output_product> outProducts = ReadOutputProducts(runInstanceId);
            SaveProductsToRepository(runInstanceId, outProducts);
        }

        private IEnumerable<output_product> ReadOutputProducts(int runInstanceId)
        {
            IEnumerable<output_product> outProducts;
            var cfg = new CsvConfiguration();
            cfg.RegisterClassMap<OutputProductMap>();
            using (var stream = _contentStorage.ReadOutputContent(runInstanceId, InputFileType.product))
            {
                using (var textReader = new StreamReader(stream, ASCIIEncoding.ASCII)) //TODO: move encoding out
                {
                    var csv = new CsvReader(textReader, cfg);
                    outProducts = csv.GetRecords<output_product>().ToArray();
                }
            }
            return outProducts;
        }

        private void SaveProductsToRepository(int runInstanceId, IEnumerable<output_product> outProducts)
        {
            var allProducts = _dataRepository.GetList<Product>();// this would be cached (not implemented), so little cost it would be
            var runInstanceProducts = _dataRepository.GetList<RunInstance_Product>(item => item.run_instance_id == runInstanceId);

            //here, for now, product in output file but not in input file will be ignored; 
            //this can be verified by doing sum in db
            var query = (from runInstanceProduct in runInstanceProducts
                        join ap in allProducts on runInstanceProduct.product_code equals ap.product_code
                        join outProduct in outProducts on ap.product_name equals outProduct.product
                        select new { runInstanceProduct, outProduct.result }).ToArray();


            foreach (var p in query)
            {
                p.runInstanceProduct.result = p.result;
            }

            var updateProds = query.Select(item => item.runInstanceProduct).ToArray();

            _dataRepository.UpdateAsync(updateProds);
        }
    }
}
