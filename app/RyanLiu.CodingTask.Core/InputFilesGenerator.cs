using Generic.DataAccess;
using RyanLiu.CodingTask.Core.Contracts;
using RyanLiu.CodingTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanLiu.CodingTask.Core
{
    public class InputFilesGenerator : IInputFilesGenerator
    {
#warning move out
        public const string INPUT_FILE_NAME_PATTERN = "input_{0}.csv"; 
        public const string OUTPUT_FILE_NAME_PATTERN = "output_{0}.csv"; 

        private readonly IEntitiesStorage _entitiesStorage;

        public InputFilesGenerator(IEntitiesStorage entitiesStorage)
        {
            this._entitiesStorage = entitiesStorage;
        }
        public async Task GenerateInputFilesAsync(int runInstanceId)
        {
            var dataRepository = DataRepositoryTool.GetDataRepository();
            var runInstance = dataRepository.GetSingle<RunInstance>(r => r.run_instance_id == runInstanceId,
                 r => r.RunInstance_Channel,
                 r => r.RunInstance_Product,
                 r => r.RunInstance_Region,
                 r => r.Setup
                );

            //mid-tier is easy to scare out, tranditional db is not, not try to put pressues on db, so here one by one
            await SaveInputProducts(runInstanceId, dataRepository, runInstance);
            await SaveInputChannels(runInstanceId, dataRepository, runInstance);
            await SaveInputRegions(runInstanceId, dataRepository, runInstance);
        }

        private async Task SaveInputProducts(int runInstanceId, IDataRepository dataRepository, RunInstance runInstance)
        {
            var selectedProductsCode = runInstance.RunInstance_Product.Select(p => p.product_code);
            var allProducts = await dataRepository.GetListAsync<Product>();
            var products = from p in allProducts
                           select new { prodcut = p.product_name, p.product_code, flag_product = selectedProductsCode.Contains(p.product_code) ? 1 : 0 };
            _entitiesStorage.SaveContent(products, runInstanceId, InputFileType.product);
        }

        private async Task SaveInputChannels(int runInstanceId, IDataRepository dataRepository, RunInstance runInstance)
        {
            var selectedProductsCode = runInstance.RunInstance_Channel.Select(c => c.channel_code);
            var allChannels = await dataRepository.GetListAsync<Channel>();
            var channels = from c in allChannels
                           select new { prodcut = c.channel_name, c.channel_code, flag_channel = selectedProductsCode.Contains(c.channel_code) ? 1 : 0 };
            _entitiesStorage.SaveContent(channels, runInstanceId, InputFileType.channel);
        }

        private async Task SaveInputRegions(int runInstanceId, IDataRepository dataRepository, RunInstance runInstance)
        {
            var selectedProductsCode = runInstance.RunInstance_Region.Select(r => r.region_code);
            var allRegions = await dataRepository.GetListAsync<Region>();
            var regions = from r in allRegions
                          select new { prodcut = r.region_name, r.region_code, flag_geography = selectedProductsCode.Contains(r.region_code) ? 1 : 0 };
            _entitiesStorage.SaveContent(regions, runInstanceId, InputFileType.geography);
        }
    }
}