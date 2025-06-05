using FluentValidation;
using MealPlanner.Commnication.Request;
using MealPlanner.Exception;
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
                .NotNull().WithMessage(MealPlannerResource.ID_NOT_NULL);
            RuleFor
                (mp => mp.Name)
                .NotEmpty().WithMessage(MealPlannerResource.NAME_INVALID);
            RuleFor
                (mp => mp.DayOfTheWeek)
                .InclusiveBetween(0, 6).WithMessage(MealPlannerResource.PARAMETER_INVALID);

        }
    }
}
