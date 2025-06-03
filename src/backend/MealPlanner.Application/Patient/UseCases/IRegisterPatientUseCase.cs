using MealPlanner.Commnication.Request;

namespace MealPlanner.Application.Patient.UseCases
{
    public interface IRegisterPatientUseCase
    {

        public Task<int> Execute(RequestRegisterPatient request);
        public void Validade(RequestRegisterPatient request);
    }
}
