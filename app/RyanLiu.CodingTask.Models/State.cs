using System;
using System.Collections.Generic;

namespace RyanLiu.CodingTask.Models
{
    public partial class State
    {
        public State()
        {
            this.Regions = new List<Region>();
        }

        public short state_code { get; set; }
        public string state_name { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
    }
}
