using System;
using System.Collections.Generic;

namespace RyanLiu.CodingTask.Models
{
    public partial class Channel
    {
        public Channel()
        {
            this.RunInstance_Channel = new List<RunInstance_Channel>();
        }

        public int channel_code { get; set; }
        public string channel_name { get; set; }
        public virtual ICollection<RunInstance_Channel> RunInstance_Channel { get; set; }
    }
}
