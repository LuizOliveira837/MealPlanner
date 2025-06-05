using MealPlanner.Commnication.Request;
using MealPlanner.Commnication.Response;
using MealPlanner.Domain.Interfaces;
using MealPlanner.Exception;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.Patient.UseCases.GetPatientMealPlan
{
    public class GetPatientMealPlanUseCase : IGetPatientMealPlanUseCase
    {
        private readonly IPatientRepository _repository;
        private readonly IMealPlanRepository _mealPlanRepository;

        public GetPatientMealPlanUseCase(IPatientRepository repository, IMealPlanRepository mealPlanRepository)
        {
            _repository = repository;
            _mealPlanRepository = mealPlanRepository;
        }
        public async Task<ResponsePatientMealPlanTodayDetail> Execute(RequestGetPatientMealPlan request)
        {
            await Validate(request);

            var dayOfWeek = (int)DateTime.Now.DayOfWeek;

            var result = await _mealPlanRepository.GetMealPlanFoodByPatient(request.Id, dayOfWeek);

            if (result == null) {

                throw new ExceptionOnValidation(new List<string>()
                {
                    "Paciente não possui plano alimentar"
                });
            }

            var response = new ResponsePatientMealPlanTodayDetail();

            response.PatientId = result.First().PatientId;
            response.PatientName = result.First().PatientName;

            var groupedMealPlans = result
                .GroupBy(r => new { r.MealPlanId, r.MealPlanName, r.DayOfTheWeek })
                .Select(g => new MealPlanInfo
                {
                    MealPlanId = g.Key.MealPlanId,
                    MealPlanName = g.Key.MealPlanName,
                    DayOfTheWeek = g.Key.DayOfTheWeek.ToString(),
                    FoodCalories = g.Select(item => new FoodCalories
                    {
                        FoodId = item.FoodId,
                        FoodName = item.FoodName,
                        PortionSizeInGrams = item.PortionSizeInGrams,
                        CaloriesPerGram = item.CaloriesPerGram,
                        TotalCaloriesPerFood = item.TotalCaloriesPerFood
                    }).ToList()
                }).ToList();

            response.MealPlanInfos = groupedMealPlans;


            return response;

        }

        public async Task Validate(RequestGetPatientMealPlan request)
        {
            var validator = new ValidateRequestGetPatientMealPlan();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var erros = result.Errors.Select(e => e.ErrorMessage.ToString()).ToList();
                throw new ExceptionOnValidation(erros);
            }

            var patient = await _repository.GetById(request.Id);
            if (patient.Equals(null))
            {
                throw new ExceptionOnValidation(new List<string>()
                {
                    MealPlannerResource.PATIENT_NOTFOUNT
                });

            }

        }
    }
}
