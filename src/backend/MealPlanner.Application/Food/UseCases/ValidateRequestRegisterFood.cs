using FluentValidation;
using MealPlanner.Commnication.Request;
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
                (food => food.Name).NotEmpty().WithName("O nome não pode ser Vazio");
           
            RuleFor
                (food => food.CaloriesPerGram)
                .NotEmpty().WithName("O nome não pode ser Vazio")
                .GreaterThanOrEqualTo(0).WithMessage("As calorias não podem ser menor que zero");

        }
    }
}
