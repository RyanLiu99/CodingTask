using RyanLiu.CodingTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RyanLiu.CodingTask.Web.Models
{
    public class InputsViewModel
    {
        public IEnumerable<SelectableRegion> Regions { get; set; }
        public IEnumerable<SelectableChannel> Chanlels { get; set; }
        public IEnumerable<SelectableProduct> Products { get; set; }

        public SetupViewModel Setup { get; set; }
        
        public IEnumerable<System.Web.Mvc.SelectListItem> OptimizationGoalListItems { get; set; }

        public InputsViewModel()
        {         
        }
    }


    // empty classes are needed for Razor. It does not take templated class as Model 
    public class SelectableRegion : SelectableEntity<Region>
    {
    }

    public class SelectableChannel: SelectableEntity<Channel>
    {
    }

    public class SelectableProduct: SelectableEntity<Product>
    {
    }

}
