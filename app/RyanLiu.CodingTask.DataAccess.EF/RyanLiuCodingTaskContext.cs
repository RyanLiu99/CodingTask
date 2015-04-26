using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using RyanLiu.CodingTask.Models.Mapping;

namespace RyanLiu.CodingTask.Models
{
    public partial class RyanLiuCodingTaskContext : DbContext
    {
        static RyanLiuCodingTaskContext()
        {
            Database.SetInitializer<RyanLiuCodingTaskContext>(null);
        }

        public RyanLiuCodingTaskContext()
            : base("Name=RyanLiuCodingTaskDbConnection")
        {
        }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<optimization_goal> optimization_goal { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<RunInstance> RunInstances { get; set; }
        public DbSet<RunInstance_Channel> RunInstance_Channel { get; set; }
        public DbSet<RunInstance_Product> RunInstance_Product { get; set; }
        public DbSet<RunInstance_Product_Chart> RunInstance_Product_Chart { get; set; }
        public DbSet<RunInstance_Region> RunInstance_Region { get; set; }
        public DbSet<Setup> Setups { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<System_Setup> System_Setup { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ChannelMap());
            modelBuilder.Configurations.Add(new optimization_goalMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new RegionMap());
            modelBuilder.Configurations.Add(new RunInstanceMap());
            modelBuilder.Configurations.Add(new RunInstance_ChannelMap());
            modelBuilder.Configurations.Add(new RunInstance_ProductMap());
            modelBuilder.Configurations.Add(new RunInstance_Product_ChartMap());
            modelBuilder.Configurations.Add(new RunInstance_RegionMap());
            modelBuilder.Configurations.Add(new SetupMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new System_SetupMap());
        }
    }
}
