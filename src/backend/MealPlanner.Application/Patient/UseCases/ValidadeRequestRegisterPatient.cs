using FluentValidation;
using MealPlanner.Commnication.Request;

namespace MealPlanner.Application.Patient.UseCases
{
    public class ValidadeRequestRegisterPatient : AbstractValidator<RequestRegisterPatient>
    {

        public ValidadeRequestRegisterPatient()
        {
            RuleFor
                (patient => patient.Name)
                .NotEmpty().WithMessage("O nome não pode ser vazio")
                .MaximumLength(40).WithMessage("O nome tem que ter no maximo 40 caracteres")
                .MinimumLength(4).WithMessage("O nome tem que ter no minimo 4 caracteres");

            RuleFor
                (Patient => Patient.Weight)
                .NotNull().WithMessage("O peso não pode ser vazio")
                .GreaterThan(10).WithMessage("O peso teve ser maior que 10 Kg");

            RuleFor
                (Patient => Patient.Height)
                .NotNull().WithMessage("A altura não pode ser vazio");

        }
    }
}
