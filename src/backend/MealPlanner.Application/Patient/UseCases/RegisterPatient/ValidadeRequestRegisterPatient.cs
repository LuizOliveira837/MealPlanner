using FluentValidation;
using MealPlanner.Commnication.Request;
using MealPlanner.Exception;

namespace MealPlanner.Application.Patient.UseCases.RegisterPatient
{
    public class ValidadeRequestRegisterPatient : AbstractValidator<RequestRegisterPatient>
    {

        public ValidadeRequestRegisterPatient()
        {
            RuleFor
                (patient => patient.Name)
                .NotEmpty().WithMessage(MealPlannerResource.NAME_INVALID)
                .MaximumLength(40).WithMessage(MealPlannerResource.PARAMETER_INVALID)
                .MinimumLength(4).WithMessage(MealPlannerResource.PARAMETER_INVALID);

            RuleFor
                (Patient => Patient.Weight)
                .NotNull().WithMessage(MealPlannerResource.PARAMETER_INVALID)
                .GreaterThan(10).WithMessage(MealPlannerResource.PARAMETER_INVALID);

            RuleFor
                (Patient => Patient.Height)
                .NotNull().WithMessage(MealPlannerResource.PARAMETER_INVALID);

        }
    }
}
