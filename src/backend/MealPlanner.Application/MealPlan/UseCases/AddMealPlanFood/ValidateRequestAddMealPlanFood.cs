using FluentValidation;
using MealPlanner.Commnication.Request;
using MealPlanner.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.MealPlan.UseCases.AddMealPlanFood
{
    public class ValidateRequestAddMealPlanFood : AbstractValidator<RequestAddMealPlanFood>
    {
        public ValidateRequestAddMealPlanFood()
        {
            RuleFor
                (mpf => mpf.FoodId).NotNull().NotEmpty().WithMessage(MealPlannerResource.ID_NOT_NULL);

            RuleFor
               (mpf => mpf.MealPlanId).NotNull().NotEmpty().WithMessage(MealPlannerResource.PARAMETER_INVALID);

            RuleFor
              (mpf => mpf.PortionSizeInGrams).NotNull().NotEmpty().WithMessage(MealPlannerResource.PARAMETER_INVALID);
        }
    }
}
