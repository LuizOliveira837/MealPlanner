using AutoMapper;
using MealPlanner.Commnication.Request;
using MealPlanner.Domain;
using MealPlanner.Domain.Interfaces;
using MealPlanner.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.MealPlan.UseCases.AddMealPlanFood
{
    public class AddMealPlanFood : IAddMealPlanFood
    {
        private readonly IFoodRepository _foodRepository;
        private IMealPlanRepository _repository;
        private readonly IMapper _mapper;

        public AddMealPlanFood(IFoodRepository foodRepository, IMealPlanRepository repository, IMapper mapper)
        {
            _foodRepository = foodRepository;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> Execute(RequestAddMealPlanFood request)
        {
            await Validade(request);

            var mealPLanFood = _mapper.Map<MealPlanFood>(request);

            var id = await _repository
                .AddMeanPlanFood(mealPLanFood);

            return id;

        }

        public async Task Validade(RequestAddMealPlanFood request)
        {
            var validator = new ValidateRequestAddMealPlanFood();


            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var erros = result.Errors.Select(e => e.ErrorMessage.ToString()).ToList();
                throw new ExceptionOnValidation(erros);
            }

            var mealPlan = await
               _repository.GetById(request.MealPlanId);

            if (mealPlan == null)
            {
                throw new ExceptionOnValidation(new List<string>()
                {
                    "mealPlan não existe"
                });

            }

            var food = await
              _foodRepository.GetById(request.FoodId);

            if (food == null)
            {
                throw new ExceptionOnValidation(new List<string>()
                {
                    "food não existe"
                });
            }


        }
    }
}
