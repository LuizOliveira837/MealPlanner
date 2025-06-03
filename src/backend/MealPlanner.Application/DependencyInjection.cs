using FluentValidation;
using MealPlanner.Application.Patient.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace MealPlanner.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services
                .AddScoped<IRegisterPatientUseCase, RegisterPatientUseCase>();

            services
                .AddValidatorsFromAssembly(typeof(ValidadeRequestRegisterPatient).Assembly);
        }
    }
}
