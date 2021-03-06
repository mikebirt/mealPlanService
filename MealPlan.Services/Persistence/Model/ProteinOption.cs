using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlan.Services.Persistence.Model
{
    public class ProteinOption
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsVegetarian { get; set; }
    }
}
