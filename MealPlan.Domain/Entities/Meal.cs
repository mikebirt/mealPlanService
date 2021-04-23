using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlan.Domain.Entities
{
    public class Meal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Cuisine { get; set; }

        public List<string> CarbOptions { get; set; }

        public List<string> Proteins { get; set; }
    }
}
