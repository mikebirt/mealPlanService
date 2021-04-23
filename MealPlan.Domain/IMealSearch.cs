using System;
using System.Collections.Generic;
using System.Text;
using MealPlan.Domain.Entities;

namespace MealPlan.Domain
{
    public interface IMealSearch
    {
        List<Meal> FindMeal(MealRequest request);
    }
}
