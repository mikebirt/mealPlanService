using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealPlan.API.Requests;
using MealPlan.Domain;
using MealPlan.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealPlan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingleMealController : ControllerBase
    {
        private IMealSearch mealSearch;

        public SingleMealController(IMealSearch mealSearch)
        {
            this.mealSearch = mealSearch;
        }

        [HttpGet]
        public IActionResult RequestSingleMeal([FromQuery] SingleMealRequest request)
        {
            MealRequest domainRquest;

            if (TryParse(request, out domainRquest))
            {
                try
                {
                    var mealResult = mealSearch.FindMeal(domainRquest);

                    return new ObjectResult(mealResult)
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
                catch(Exception e)
                {
                    string error = e.Message;
                }

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }

        private static bool TryParse(SingleMealRequest request, out MealRequest domainRequest)
        {
            domainRequest = new MealRequest
            {
                LowCarbOption = request.LowCarbOption,
                VegetarianOption = request.VegetarianOption
            };

            try
            {
                if (request.CuisineFilter != null && request.CuisineFilter.Length > 0)
                {
                    domainRequest.IncludeCuisines = request.CuisineFilter.Select(c => Enum.Parse<CuisineType>(c.ToString())).ToList();
                }

                if (request.PrepTimeFilter != null && request.PrepTimeFilter.Length > 0)
                {
                    domainRequest.IncludePrepTimes = request.PrepTimeFilter.Select(c => Enum.Parse<PrepTimeOptionsType>(c.ToString())).ToList();
                }

                if (request.ExcludeCarbIds != null && request.ExcludeCarbIds.Length > 0)
                {
                    domainRequest.ExcludeCarbs = request.ExcludeCarbIds.Select(c => Enum.Parse<CarbOptionsType>(c.ToString())).ToList();
                }

                if (request.IncludeCarbIds != null && request.IncludeCarbIds.Length > 0)
                {
                    domainRequest.IncludeCarbs = request.IncludeCarbIds.Select(c => Enum.Parse<CarbOptionsType>(c.ToString())).ToList();
                }

                if (request.ExcludeProteinIds != null && request.ExcludeProteinIds.Length > 0)
                {
                    domainRequest.ExcludeProteins = request.ExcludeProteinIds.Select(c => Enum.Parse<ProteinOptionsType>(c.ToString())).ToList();
                }

                if (request.IncludeProteinIds != null && request.IncludeProteinIds.Length > 0)
                {
                    domainRequest.IncludeProteins = request.IncludeProteinIds.Select(c => Enum.Parse<ProteinOptionsType>(c.ToString())).ToList();
                }

                return true;
            }
            catch { }

            return false;
        }
    }
}
