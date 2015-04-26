using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RyanLiu.CodingTask.Core.Contracts
{
    public enum InputFileType { channel, geography, product, setup};

    public interface IContentStorage
    {
        //Task<string> SaveContentAsync(Stream content, int runInstanceId, InputFileType storeContentType);

        Stream ReadOutputContent(int runInstanceId, InputFileType storeContentType);

        TextWriter GetDestnationWriter(int runInstanceId, InputFileType storeContentType, Encoding encoding);
     
        //depends how Script runs, if possible rather this method is not exposed
        string GetRunInstanceDirectory(int runInstanceId);
    }
}
