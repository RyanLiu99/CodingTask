using System;
using System.Collections.Generic;

namespace RyanLiu.CodingTask.Models
{
    public partial class RunInstance_Product
    {
        public int run_instance_id { get; set; }
        public int product_code { get; set; }
        public int result { get; set; }
        public virtual Product Product { get; set; }
        public virtual RunInstance RunInstance { get; set; }
    }
}
