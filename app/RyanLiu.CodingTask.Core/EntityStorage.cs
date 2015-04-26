using CsvHelper;
using RyanLiu.CodingTask.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanLiu.CodingTask.Core
{
    /// <summary>
    /// save entities to storage (e.g. file system or Azure blob)
    /// </summary>
    public class EntitiesStorage : IEntitiesStorage
    {
        private readonly IContentStorage _contentStorage;
        public EntitiesStorage(IContentStorage contentStorage)
        {
            this._contentStorage = contentStorage;
        }

        // pass in inputFileType rather get from TEntity, is to allow TEntity to be EF proxy type, or anonymous type
        public void SaveContent<TEntity>(IEnumerable<TEntity> entities, int runInstanceId, InputFileType inputFileType)
        {
#warning move encoding out
            using (var textWriter = _contentStorage.GetDestnationWriter(runInstanceId, inputFileType, ASCIIEncoding.ASCII))
            {
                var csvWriter = new CsvWriter(textWriter);                
                csvWriter.WriteRecords(entities);
            }
        }

     

    }
}
