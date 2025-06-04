using MealPlanner.Domain.Interfaces;
using MealPlanner.Persistence.Database;
using MealPlanner.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        }
    }
}
