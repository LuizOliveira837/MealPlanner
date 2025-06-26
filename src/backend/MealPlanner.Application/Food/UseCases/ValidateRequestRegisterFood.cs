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
                (food => food.Name).NotEmpty().WithMessage(MealPlannerResource.FOOD_NAME_INVALID);

            RuleFor
                (food => food.CaloriesPerGram)
                .GreaterThanOrEqualTo(0).WithMessage(MealPlannerResource.CALORIES_INVALID);

        }
    }
}
