using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealPlan.Domain;
using MealPlan.Domain.Services.Persistence;
using MealPlan.External.Persistence;
using MealPlan.Services.External.Persistence;
using MealPlan.Services.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MealPlan.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IMealSearch, MealSearch>();
            services.AddTransient<IMealRepository, MealRepository>();

            IConfigurationSection databaseOptionsSection = Configuration.GetSection("MealDB");
            var ConnectionString = databaseOptionsSection["ConnectionString"];
            services.AddDbContextPool<IMealContext, MealContext>(options => options.UseSqlServer(databaseOptionsSection["ConnectionString"]));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
