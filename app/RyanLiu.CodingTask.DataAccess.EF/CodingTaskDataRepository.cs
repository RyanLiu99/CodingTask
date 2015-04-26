using Generic.DataAccess.EF;
using Generic.Log;
using RyanLiu.CodingTask.Models;

namespace Survey.DataAccess.EF
{
    public class CodingTaskDataRepository : BaseDataRepositoryEF
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override System.Data.Entity.DbContext GetDbContext()
        {
            var context = new RyanLiuCodingTaskContext();  

            //for context.Configuration, defaults:
            //false: LazyLoadingEnabled, UseDataBaseNullSemantics
            //true: AutoDetectChangesEnabled, ProxyCreatinoEnabled, ValidateOnSaveEnabled

            context.Configuration.ValidateOnSaveEnabled = false; //some time I use partial objects
            context.Database.Log = Log.Debug;
            context.Configuration.AutoDetectChangesEnabled = false; 
            return context;
        }
    }
}
