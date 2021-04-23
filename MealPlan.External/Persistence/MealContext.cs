using System;
using System.Collections.Generic;
using System.Text;
using MealPlan.Services.External.Persistence;
using MealPlan.Services.Persistence.Model;
using Microsoft.EntityFrameworkCore;

namespace MealPlan.External.Persistence
{
    public class MealContext : DbContext, IMealContext
    {
        public MealContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<CarbohydrateOption> CarbohydrateOption { get; set; }

        public DbSet<Cuisine> Cuisine { get; set; }

        public DbSet<Meal> Meal { get; set; }

        public DbSet<MealCarbohydrateOption> MealCarbohydrateOption { get; set; }

        public DbSet<MealProteinOption> MealProteinOption { get; set; }

        public DbSet<PreperationTime> PreperationTime { get; set; }

        public DbSet<ProteinOption> ProteinOption { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Method called by base code")]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarbohydrateOption>(b =>
            {
                b.Property("Id");
                b.HasKey("Id");
            })
            .Entity<Cuisine>(b =>
            {
                b.Property("Id");
                b.HasKey("Id");
            })
            .Entity<Meal>(b =>
            {
                b.Property("Id");
                b.HasKey("Id");
            })
            .Entity<MealCarbohydrateOption>(b =>
            {
                b.HasKey("MealId", "CarbohydrateOptionId");
            })
            .Entity<MealProteinOption>(b =>
            {
                b.HasKey("MealId", "ProteinOptionId");
            })
            .Entity<PreperationTime>(b =>
            {
                b.Property("Id");
                b.HasKey("Id");
            })
            .Entity<ProteinOption>(b =>
            {
                b.Property("Id");
                b.HasKey("Id");
            });
        }
    }
}
