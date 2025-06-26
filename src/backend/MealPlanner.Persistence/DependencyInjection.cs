using FluentMigrator.Runner;
using MealPlanner.Domain.Interfaces;
using MealPlanner.Persistence.Database;
using MealPlanner.Persistence.Interfaces;
using MealPlanner.Persistence.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MealPlanner.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<MealPlannerContext>(opt =>
                {
                    opt.UseSqlServer(configuration.GetConnectionString("MealPlanner"));
                });


            services
                .AddScoped<IPatientRepository, PatientRepository>();

            services
                .AddScoped<IFoodRepository, FoodRepository>();

            services
                .AddScoped<IMealPlanRepository, MealPlanRepository>();

            services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb =>
                {

                    rb.AddSqlServer()
                    .WithGlobalConnectionString(configuration.GetConnectionString("MealPlanner"))
                    .ScanIn(Assembly.Load("MealPlanner.Persistence")).For.All();
                    
                });
        }
    }
}

