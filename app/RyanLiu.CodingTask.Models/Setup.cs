using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RyanLiu.CodingTask.Models
{
    public partial class Setup
    {
        public Setup()
        {
            this.RunInstances = new List<RunInstance>();
        }

        
        public int setup_id { get; set; }

        
        public byte optimization_goal_id { get; set; }


        public int optimization_goal_value { get; set; }
        public System.DateTime date_start { get; set; }
        public System.DateTime date_end { get; set; }
        public int input_increment { get; set; }
        public virtual optimization_goal optimization_goal { get; set; }
        public virtual ICollection<RunInstance> RunInstances { get; set; }
    }
}
