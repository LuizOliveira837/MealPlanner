using FluentValidation;
using MealPlanner.Commnication.Request;
using MealPlanner.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.Patient.UseCases.GetPatient
{
    public class ValidateRequestGetPatientById : AbstractValidator<RequestGetPatientById>
    {

        public ValidateRequestGetPatientById()
        {
            RuleFor
                (p => p.Id).NotNull().WithMessage(MealPlannerResource.ID_NOT_NULL);

        }
    }
}
