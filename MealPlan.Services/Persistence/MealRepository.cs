using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MealPlan.Domain.Entities;
using MealPlan.Domain.Services.Persistence;
using MealPlan.Services.External.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MealPlan.Services.Persistence
{
    public class MealRepository : IMealRepository
    {
        private readonly IMealContext dataContext;
        public MealRepository(IMealContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<Meal> GetMeals(MealRequest request)
        {
            IEnumerable<int> prepTimes = request.IncludePrepTimes?.Select(prepTime => (int)prepTime);
            IEnumerable<int> cuisines = request.IncludeCuisines?.Select(cuisine => (int)cuisine);
            IEnumerable<int> includeCarbOptions = request.IncludeCarbs?.Select(co => (int)co);
            IEnumerable<int> excludeCarbOptions = request.ExcludeCarbs?.Select(co => (int)co);
            IEnumerable<int> includeProteinOptions = request.IncludeProteins?.Select(po => (int)po);
            IEnumerable<int> excludeProteinOptions = request.ExcludeProteins?.Select(po => (int)po);

            var meals = from m in dataContext.Meal
                        join mco in dataContext.MealCarbohydrateOption on m.Id equals mco.MealId
                        join co in dataContext.CarbohydrateOption on mco.CarbohydrateOptionId equals co.Id
                        join mpo in dataContext.MealProteinOption on m.Id equals mpo.MealId
                        join po in dataContext.ProteinOption on mpo.ProteinOptionId equals po.Id
                        join c in dataContext.Cuisine on m.CuisineId equals c.Id
                        where (prepTimes == null || prepTimes.Count() == 0 || prepTimes.Contains(m.PreperationTimeId) == true)

                        && (cuisines == null || cuisines.Count() == 0 || cuisines.Contains(m.CuisineId) == true)

                        && (includeCarbOptions == null || includeCarbOptions.Count() == 0 || includeCarbOptions.Contains(co.Id))
                        && (excludeCarbOptions == null || excludeCarbOptions.Count() == 0 || !excludeCarbOptions.Contains(co.Id))

                        && (includeProteinOptions == null || includeProteinOptions.Count() == 0 || includeProteinOptions.Contains(po.Id))
                        && (excludeProteinOptions == null || excludeProteinOptions.Count() == 0 || !excludeProteinOptions.Contains(po.Id))

                        && (request.VegetarianOption == null || po.IsVegetarian == request.VegetarianOption)
                        && (request.LowCarbOption == null || co.IsLowCarbOption == request.LowCarbOption)

                        select new
                        {
                            MealId = m.Id,
                            MealName = m.Name,
                            CarbName = co.Name,
                            ProteinName = po.Name,
                            CuisineName = c.Name
                        };

            var QueryResults = meals.ToList();

            List<Meal> results = new List<Meal>();

            List<int> mealIds = QueryResults.Select(m => m.MealId).Distinct().ToList();

            foreach(var mealId in mealIds)
            {
                results.Add(new Meal
                {
                    Id = mealId,
                    Name = QueryResults.First(m => m.MealId == mealId).MealName,
                    Cuisine = QueryResults.First(m => m.MealId == mealId).CuisineName,
                    CarbOptions = QueryResults.Where(m => m.MealId == mealId).Select(m => m.CarbName).Distinct().ToList(),
                    Proteins = QueryResults.Where(m => m.MealId == mealId).Select(m => m.ProteinName).Distinct().ToList(),
                });
            }

            return results;
        }
    }
}
