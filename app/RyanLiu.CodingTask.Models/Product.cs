using System;
using System.Collections.Generic;

namespace RyanLiu.CodingTask.Models
{
    public partial class Product
    {
        public Product()
        {
            this.RunInstance_Product_Chart = new List<RunInstance_Product_Chart>();
            this.RunInstance_Product = new List<RunInstance_Product>();
        }

        public int product_code { get; set; }
        public string product_name { get; set; }
        public virtual ICollection<RunInstance_Product_Chart> RunInstance_Product_Chart { get; set; }
        public virtual ICollection<RunInstance_Product> RunInstance_Product { get; set; }
    }
}
