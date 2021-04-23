using System;
using System.Collections.Generic;
using System.Text;
using MealPlan.Domain.Entities;

namespace MealPlan.Domain.Services.Persistence
{
    public interface IMealRepository
    {
        public List<Meal> GetMeals(MealRequest request);
    }
}
