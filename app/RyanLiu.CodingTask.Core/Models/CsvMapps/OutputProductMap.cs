using CsvHelper.Configuration;
using RyanLiu.CodingTask.Core.Models.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanLiu.CodingTask.Core.Models.CsvMapps
{
    public class OutputProductMap : CsvClassMap<output_product>
    {
        public OutputProductMap()
        {
            Map(m => m.product);
            Map(m => m.result).Name("units sold");
        }
    }
}
