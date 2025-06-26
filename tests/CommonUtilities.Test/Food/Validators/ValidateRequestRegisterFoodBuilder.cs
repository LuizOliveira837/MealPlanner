using MealPlanner.Application.Food.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities.Test.Food.Validators
{
    public static class ValidateRequestRegisterFoodBuilder
    {
        public static ValidateRequestRegisterFood Build()
        {
            return new ValidateRequestRegisterFood();
        }
    }
}
