using AutoMapper;
using MealPlanner.Commnication.Request;
using MealPlanner.Domain.Interfaces;
using MealPlanner.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MealPlanner.Application.MealPlan.UseCases.RegisterMealPlan
{
    public class RegisterMealPlanUseCase : IRegisterMealPlanUseCase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMealPlanRepository _repository;
        private readonly IMapper _mapper;

        public RegisterMealPlanUseCase(IPatientRepository patientRepository, IMealPlanRepository repository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> Execute(RequestRegisterMealPlan request)
        {
            await Validate(request);

           


            var mealPlan = _mapper.Map<Domain.MealPlan>(request);

            var id = await _repository
                 .Create(mealPlan);

            return id;

        }

        public async Task Validate(RequestRegisterMealPlan request)
        {
            var validator = new ValidadeRegisterMealPlanUseCase();


            var result = validator.Validate(request);

            var patient = await _patientRepository.GetById(request.PatientId);

            if (patient == null)
            {

                throw new ExceptionOnValidation(new List<string>()
                {
                    MealPlannerResource.PATIENT_NOTFOUNT
                });

            }


            if (!result.IsValid)
            {
                var erros = result.Errors.Select(e => e.ErrorMessage.ToString()).ToList();
                throw new ExceptionOnValidation(erros);
            }
        }
    }
}
