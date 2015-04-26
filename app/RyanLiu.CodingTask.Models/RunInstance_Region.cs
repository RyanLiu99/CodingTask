using System;
using System.Collections.Generic;

namespace RyanLiu.CodingTask.Models
{
    public partial class RunInstance_Region
    {
        public int run_instance_id { get; set; }
        public int region_code { get; set; }
        public int result { get; set; }
        public virtual Region Region { get; set; }
        public virtual RunInstance RunInstance { get; set; }
    }
}
