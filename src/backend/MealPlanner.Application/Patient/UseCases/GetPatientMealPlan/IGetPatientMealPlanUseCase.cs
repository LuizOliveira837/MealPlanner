using MealPlanner.Commnication;
using MealPlanner.Commnication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.Patient.UseCases.GetPatientMealPlan
{
    public interface IGetPatientMealPlanUseCase
    {
        public Task<ResponsePatientMealPlanTodayDetail> Execute(RequestGetPatientMealPlan id);
        public Task Validate(RequestGetPatientMealPlan id);
    }
}
