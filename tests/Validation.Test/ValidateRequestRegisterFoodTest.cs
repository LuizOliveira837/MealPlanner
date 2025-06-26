using CommonUtilities.Test.Food.Request;
using CommonUtilities.Test.Food.Validators;
using FluentAssertions;
using MealPlanner.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.Test
{
    public class ValidateRequestRegisterFoodTest
    {
        [Fact]
        public void Sucess()
        {
            //ARRANGE
            var validator = ValidateRequestRegisterFoodBuilder.Build();
            var requestRegisterFood = RequestRegisterFoodBuilder.Build();

            //ACT

            var result = validator.Validate(requestRegisterFood);


            //ASSERT

            result.IsValid.Should().BeTrue();
        }


        [Fact]
        public void ERROR_FOOD_NAME_INVALID()
        {
            //ARRANGE
            var validator = ValidateRequestRegisterFoodBuilder.Build();
            var requestRegisterFood = RequestRegisterFoodBuilder.Build();

            requestRegisterFood.Name = string.Empty;

            //ACT

            var result = validator.Validate(requestRegisterFood);


            //ASSERT

            result.IsValid.Should().BeFalse();

            result.Errors.Should()
                .ContainSingle();

            result.Errors.Where(x => x.ErrorMessage == MealPlannerResource.FOOD_NAME_INVALID)
                .Should()
                .ContainSingle();
        }

        [Fact]
        public void ERROR_CALORIES_INVALID()
        {
            //ARRANGE
            var validator = ValidateRequestRegisterFoodBuilder.Build();
            var requestRegisterFood = RequestRegisterFoodBuilder.Build();

            requestRegisterFood.CaloriesPerGram = 0;

            //ACT

            var result = validator.Validate(requestRegisterFood);


            //ASSERT

            result.IsValid.Should().BeFalse();

            result.Errors.Should().ContainSingle();

            result.Errors.Where(x => x.ErrorMessage == MealPlannerResource.CALORIES_INVALID)
                .Should()
                .ContainSingle();
        }
    }
}
