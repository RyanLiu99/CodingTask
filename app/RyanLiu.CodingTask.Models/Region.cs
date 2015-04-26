using System;
using System.Collections.Generic;

namespace RyanLiu.CodingTask.Models
{
    public partial class Region
    {
        public Region()
        {
            this.RunInstance_Region = new List<RunInstance_Region>();
        }

        public int region_code { get; set; }
        public string region_name { get; set; }
        public short stat_code { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<RunInstance_Region> RunInstance_Region { get; set; }
    }
}
