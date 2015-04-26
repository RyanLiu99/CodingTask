using RyanLiu.CodingTask.Core.Contracts;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RyanLiu.CodingTask.Core
{
    public class FileSystemCotentStorage : IContentStorage
    {

#warning should read from outside
        const string fileStorageRootFolder = @"c:\temp\codingTaskStorage\";

        public FileSystemCotentStorage()
        {             
        }

        //public async Task<string> SaveContentAsync(Stream content, int runInstanceId, InputFileType storeContentType)
        //{
        //    Directory.CreateDirectory(GetRunInstanceDirectory(runInstanceId));            

        //    string filePath = GetFilePath(runInstanceId, storeContentType);
        //    using (var f = File.Create(filePath, 20480, FileOptions.Asynchronous))
        //    {
        //        await content.CopyToAsync(f);
        //        return filePath;
        //    }
        //}

        public Stream ReadOutputContent(int runInstanceId, InputFileType storeContentType)
        {
            string filePath = GetOutputFilePath(runInstanceId, storeContentType);
            return File.OpenRead(filePath);
        }

        public TextWriter GetDestnationWriter(int runInstanceId, InputFileType storeContentType, Encoding encoding)
        {
            Directory.CreateDirectory(GetRunInstanceDirectory(runInstanceId));
            string filePath = GetInputFilePath(runInstanceId, storeContentType);
            return new StreamWriter(filePath, false, encoding, 20480);
        }
  
        public string GetRunInstanceDirectory(int runInstanceId)
        {
            return Path.Combine(fileStorageRootFolder, runInstanceId.ToString());
        }

        #region private methods

        private string GetInputFilePath(int runInstanceId, InputFileType storeContentType)
        {
            return Path.Combine(GetRunInstanceDirectory(runInstanceId), 
                string.Format(InputFilesGenerator.INPUT_FILE_NAME_PATTERN, storeContentType));
        }

        private string GetOutputFilePath(int runInstanceId, InputFileType storeContentType)
        {
            return Path.Combine(GetRunInstanceDirectory(runInstanceId),
                string.Format(InputFilesGenerator.OUTPUT_FILE_NAME_PATTERN, storeContentType));
        }
        #endregion


       
    }
}
