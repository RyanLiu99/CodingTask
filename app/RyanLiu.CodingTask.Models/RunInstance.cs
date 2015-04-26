using System;
using System.Collections.Generic;

namespace RyanLiu.CodingTask.Models
{
    public partial class RunInstance
    {
        public RunInstance()
        {
            this.RunInstance_Channel = new List<RunInstance_Channel>();
            this.RunInstance_Product_Chart = new List<RunInstance_Product_Chart>();
            this.RunInstance_Product = new List<RunInstance_Product>();
            this.RunInstance_Region = new List<RunInstance_Region>();
        }

        public int run_instance_id { get; set; }
        public int setup_id { get; set; }
        public Nullable<System.DateTime> run_start { get; set; }
        public Nullable<System.DateTime> run_end { get; set; }
        public string path { get; set; }
        public string note { get; set; }
        public virtual ICollection<RunInstance_Channel> RunInstance_Channel { get; set; }
        public virtual ICollection<RunInstance_Product_Chart> RunInstance_Product_Chart { get; set; }
        public virtual ICollection<RunInstance_Product> RunInstance_Product { get; set; }
        public virtual ICollection<RunInstance_Region> RunInstance_Region { get; set; }
        public virtual Setup Setup { get; set; }
    }
}
