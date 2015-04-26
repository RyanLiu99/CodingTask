using Generic.DataAccess;
using RyanLiu.CodingTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RyanLiu.CodingTask.Web.Utilities
{
    public static class SelectListItemsUtility
    {
        public static async Task<IEnumerable<SelectListItem>> GetOptimizationGoals()
        {
            var _dataRepository = DataRepositoryTool.GetDataRepository();

            var optimizationGoalListItems = await _dataRepository.GetListProjectedAsync<optimization_goal, SelectListItem>(
                g =>  new SelectListItem()
                                            {
                                                Text = g.optimization_goal1,
                                                Value = g.optimization_goal_id.ToString()
                                            }
                );
           

            return optimizationGoalListItems;
  
        }
    }
}