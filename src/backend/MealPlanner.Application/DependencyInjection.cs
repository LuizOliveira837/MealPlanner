using FluentValidation;
using MealPlanner.Application.Food.UseCases;
using MealPlanner.Application.MealPlan.UseCases.AddMealPlanFood;
using MealPlanner.Application.MealPlan.UseCases.RegisterMealPlan;
using MealPlanner.Application.Patient.UseCases.DeletePatient;
using MealPlanner.Application.Patient.UseCases.GetPatient;
using MealPlanner.Application.Patient.UseCases.GetPatientMealPlan;
using MealPlanner.Application.Patient.UseCases.RegisterPatient;
using MealPlanner.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MealPlanner.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {

            services
                .AddAutoMapper(typeof(MealPlannerMapper).Assembly);

            services
                .AddScoped<IRegisterPatientUseCase, RegisterPatientUseCase>();

            services
                .AddScoped<IDeletePatientUseCase, DeletePatientUseCase>();

            services
               .AddScoped<IRegisterFoodUseCase, RegisterFoodUseCase>();

            services
               .AddScoped<IRegisterMealPlanUseCase, RegisterMealPlanUseCase>();

            services
                .AddScoped<IGetPatientByIdUseCase, GetPatientByIdUseCase>();

            services
               .AddScoped<IAddMealPlanFood, AddMealPlanFood>();

            services
              .AddScoped<IGetPatientMealPlanUseCase, GetPatientMealPlanUseCase>();



            services
                .AddValidatorsFromAssembly(typeof(ValidadeRequestRegisterPatient).Assembly);
        }
    }
}
