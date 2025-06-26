using CommonUtilities.Test.Food.Repositories;
using CommonUtilities.Test.Food.Request;
using CommonUtilities.Test.Services;
using FluentAssertions;
using MealPlanner.Application.Food.UseCases;
using MealPlanner.Exception;

namespace UseCase.Test.Food
{
    public class AddMealPlanFoodTest
    {


        public RegisterFoodUseCase CreateUseCase(MealPlanner.Domain.Food food, Guid guid)
        {
            var foodRepositoryBuilder = new FoodRepositoryBuilder();
            var mapper = MappingsBuilder.Build();
            var useCase = new RegisterFoodUseCase(foodRepositoryBuilder.FoodRepository.Object, mapper);


            foodRepositoryBuilder.Create(food, guid);



            return useCase;
        }


        [Fact]
        public async Task Sucess()
        {
            //ARRANGE
            var guid = Guid.NewGuid();
            var requestRegisterFoodBuilder = RequestRegisterFoodBuilder.Build();
            var food = new MealPlanner.Domain.Food(requestRegisterFoodBuilder.Name, requestRegisterFoodBuilder.CaloriesPerGram);
            var useCase = CreateUseCase(food, guid);


            //ACT
            var result = await useCase.Execute(requestRegisterFoodBuilder);


            //ASSERT
            result
                .Should()
                .NotBe(Guid.Empty)
                .And
                .Be(guid);



        }


        [Fact]
        public async Task ERRO_NAME_INVALID()
        {
            //ARRANGE
            var guid = Guid.NewGuid();
            var requestRegisterFoodBuilder = RequestRegisterFoodBuilder.Build();
            var food = new MealPlanner.Domain.Food(requestRegisterFoodBuilder.Name, requestRegisterFoodBuilder.CaloriesPerGram);
            var useCase = CreateUseCase(food, guid);

            requestRegisterFoodBuilder.Name = string.Empty;

            //ACT
            Func<Task> exe = async () => await useCase.Execute(requestRegisterFoodBuilder);


            var t = exe
             .Should()
             .ThrowAsync<ExceptionOnValidation>()
             .Where(e => e.ErrorMensages.Count() == 1 && e.ErrorMensages.Contains(MealPlannerResource.FOOD_NAME_INVALID));
             


        }


        [Fact]
        public async Task ERRO_CALORIES_INVALID()
        {
            //ARRANGE
            var guid = Guid.NewGuid();
            var requestRegisterFoodBuilder = RequestRegisterFoodBuilder.Build();
            var food = new MealPlanner.Domain.Food(requestRegisterFoodBuilder.Name, requestRegisterFoodBuilder.CaloriesPerGram);
            var useCase = CreateUseCase(food, guid);

            requestRegisterFoodBuilder.CaloriesPerGram = 0;

            //ACT
            Func<Task> exe = async () => await useCase.Execute(requestRegisterFoodBuilder);


            var t = exe
             .Should()
             .ThrowAsync<ExceptionOnValidation>()
             .Where(e => e.ErrorMensages.Count() == 1 && e.ErrorMensages.Contains(MealPlannerResource.CALORIES_INVALID));



        }
    }
}
