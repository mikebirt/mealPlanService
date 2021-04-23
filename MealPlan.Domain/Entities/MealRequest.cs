using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlan.Domain.Entities
{
    public class MealRequest
    {
        public List<CarbOptionsType> IncludeCarbs { get; set; }

        public List<CarbOptionsType> ExcludeCarbs { get; set; }

        public bool? LowCarbOption { get; set; }

        public List<ProteinOptionsType> IncludeProteins { get; set; }

        public List<ProteinOptionsType> ExcludeProteins { get; set; }

        public bool? VegetarianOption { get; set; }

        public List<PrepTimeOptionsType> IncludePrepTimes { get; set; }

        public List<CuisineType> IncludeCuisines { get; set; }
    }
}
