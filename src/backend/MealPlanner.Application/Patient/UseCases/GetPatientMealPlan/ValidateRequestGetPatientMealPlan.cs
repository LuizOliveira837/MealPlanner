using FluentValidation;
using MealPlanner.Commnication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.Patient.UseCases.GetPatientMealPlan
{
    public class ValidateRequestGetPatientMealPlan : AbstractValidator<RequestGetPatientMealPlan>
    {
        public ValidateRequestGetPatientMealPlan()
        {
            RuleFor
                 (request => request.Id)
                 .NotNull().NotEmpty().WithMessage("O id não pode ser vazio");
        }
    }
}
