﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanLiu.CodingTask.Core.Contracts
{
    public interface IOutputsSaver
    {
        void SaveOutputs(int runInstanceId);
    }
}
