using System;
using System.Collections.Generic;

namespace RyanLiu.CodingTask.Models
{
    public partial class optimization_goal
    {
        public optimization_goal()
        {
            this.Setups = new List<Setup>();
        }

        public byte optimization_goal_id { get; set; }
        public string optimization_goal1 { get; set; }
        public virtual ICollection<Setup> Setups { get; set; }
    }
}
