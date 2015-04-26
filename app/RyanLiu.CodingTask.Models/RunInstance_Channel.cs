using System;
using System.Collections.Generic;

namespace RyanLiu.CodingTask.Models
{
    public partial class RunInstance_Channel
    {
        public int run_instance_id { get; set; }
        public int channel_code { get; set; }
        public int result { get; set; }
        public virtual Channel Channel { get; set; }
        public virtual RunInstance RunInstance { get; set; }
    }
}
