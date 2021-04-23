using System;
using System.Collections.Generic;
using System.Text;
using MealPlan.Services.Persistence.Model;
using Microsoft.EntityFrameworkCore;

namespace MealPlan.Services.External.Persistence
{
    public interface IMealContext
    {
        public DbSet<CarbohydrateOption> CarbohydrateOption { get; set; }

        public DbSet<Cuisine> Cuisine { get; set; }

        public DbSet<Meal> Meal { get; set; }

        public DbSet<MealCarbohydrateOption> MealCarbohydrateOption { get; set; }

        public DbSet<MealProteinOption> MealProteinOption { get; set; }

        public DbSet<PreperationTime> PreperationTime { get; set; }

        public DbSet<ProteinOption> ProteinOption { get; set; }
    }
}
