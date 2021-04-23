using System;
using System.Collections.Generic;
using System.Text;
using MealPlan.Domain.Entities;
using MealPlan.Domain.Services.Persistence;

namespace MealPlan.Domain
{
    public class MealSearch : IMealSearch
    {
        private IMealRepository mealRepository;

        public MealSearch(IMealRepository mealRepository)
        {
            this.mealRepository = mealRepository;
        }

        public List<Meal> FindMeal(MealRequest request)
        {
            return mealRepository.GetMeals(request);
        }
    }
}
