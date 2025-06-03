using AutoMapper;
using MealPlanner.Application.Services;
using MealPlanner.Commnication.Request;

namespace MealPlanner.Application.Patient.UseCases
{
    public class RegisterPatientUseCase : IRegisterPatientUseCase
    {
        public Task<int> Execute(RequestRegisterPatient request)
        {

            //VALIDAÇÃO

            Validade(request);

            //MAPEAMENTO

            var mapper = new Mapper(new MapperConfiguration(conf =>
            {
                conf.AddProfile(new MealPlannerMapper());
            }));

            var user = mapper.Map<RequestRegisterPatient>(request);


            //CRIAÇÃO COM BD

            return Task.FromResult(1);
        }

        public void Validade(RequestRegisterPatient request)
        {
            var validator = new ValidadeRequestRegisterPatient();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                throw new Exception(result
                    .Errors[0]
                    .ToString());
            }
        }
    }
}
