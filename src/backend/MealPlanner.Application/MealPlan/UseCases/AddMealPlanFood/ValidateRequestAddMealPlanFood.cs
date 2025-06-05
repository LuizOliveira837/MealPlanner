using FluentValidation;
using MealPlanner.Commnication.Request;
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
                (mpf => mpf.FoodId).NotNull().NotEmpty().WithMessage("O id da comida não pode estar vazio");

            RuleFor
               (mpf => mpf.MealPlanId).NotNull().NotEmpty().WithMessage("O PLano de alimentação não pode estar vazio");

            RuleFor
              (mpf => mpf.PortionSizeInGrams).NotNull().NotEmpty().WithMessage("A porção não pode estar vazio");
        }
    }
}
