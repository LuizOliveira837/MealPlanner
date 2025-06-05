using FluentValidation;
using MealPlanner.Commnication.Request;
using MealPlanner.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.Food.UseCases
{
    public class ValidateRequestRegisterFood : AbstractValidator<RequestRegisterFood>
    {
        public ValidateRequestRegisterFood()
        {
            RuleFor
                (food => food.Name).NotEmpty().WithName(MealPlannerResource.PARAMETER_INVALID);
           
            RuleFor
                (food => food.CaloriesPerGram)
                .NotEmpty().WithName(MealPlannerResource.PARAMETER_INVALID)
                .GreaterThanOrEqualTo(0).WithMessage(MealPlannerResource.PARAMETER_INVALID);

        }
    }
}
