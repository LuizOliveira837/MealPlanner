using FluentValidation;
using MealPlanner.Commnication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.MealPlan.UseCases.RegisterMealPlan
{
    public class ValidadeRegisterMealPlanUseCase : AbstractValidator<RequestRegisterMealPlan>
    {
        public ValidadeRegisterMealPlanUseCase()
        {
            RuleFor
                (mp => mp.PatientId)
                .NotNull().WithMessage("Id do paciente não pode ser nulo");
            RuleFor
                (mp => mp.Name)
                .NotEmpty().WithMessage("O nome não pode ser vazio");
            RuleFor
                (mp => mp.DayOfTheWeek)
                .InclusiveBetween(0, 6);
        }
    }
}
