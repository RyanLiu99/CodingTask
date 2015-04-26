using RyanLiu.CodingTask.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RyanLiu.CodingTask.Web.Models
{
    public class SetupViewModel
    {
        public int? setup_id { get; set; }

        public byte optimization_goal_id { get; set; }
        public int optimization_goal_value { get; set; }
        [Required]
        public System.DateTime? date_start { get; set; }
        [Required]        
        public System.DateTime? date_end { get; set; }

        internal Setup ToModel()
        {
            //here I can also use utility like object mapper to copy properties

#warning input_increment should get from system
            return new Setup() { 
                 setup_id = setup_id.GetValueOrDefault(0),
                 input_increment = 5000,
                 date_start = date_start.Value,
                 date_end = date_end.Value,
                 optimization_goal_id = optimization_goal_id,
                 optimization_goal_value = optimization_goal_value
            };
        }
    }
}