using MealPlanner.Commnication.Request;

namespace MealPlanner.Application.Patient.UseCases.RegisterPatient
{
    public interface IRegisterPatientUseCase
    {

        public Task<Guid> Execute(RequestRegisterPatient request);
        public void Validade(RequestRegisterPatient request);
    }
}
