using AutoMapper;
using MealPlanner.Application.Services;
using MealPlanner.Commnication.Request;
using MealPlanner.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.Food.UseCases
{
    public class RegisterFoodUseCase : IRegisterFoodUseCase
    {
        private readonly IFoodRepository _repository;
        private readonly IMapper _mapper;

        public RegisterFoodUseCase(IFoodRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> Execute(RequestRegisterFood request)
        {
            await Validade(request);


            var food = _mapper.Map<MealPlanner.Domain.Food>(request);

            var id = await _repository.Create(food);

            return id;

        }

        public async Task Validade(RequestRegisterFood request)
        {
            var validator = new ValidateRequestRegisterFood();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                throw new Exception(result
                    .Errors[0].ToString());
            }
        }
    }
}
