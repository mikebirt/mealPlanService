using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlan.API.Requests
{
    public class SingleMealRequest
    {
        public int[] IncludeCarbIds { get; set; }

        public int[] ExcludeCarbIds { get; set; }

        public bool? LowCarbOption { get; set; }

        public int[] IncludeProteinIds { get; set; }

        public int[] ExcludeProteinIds { get; set; }

        public bool? VegetarianOption { get; set; }

        public int[] PrepTimeFilter { get; set; }

        public int[] CuisineFilter { get; set; }
    }
}
