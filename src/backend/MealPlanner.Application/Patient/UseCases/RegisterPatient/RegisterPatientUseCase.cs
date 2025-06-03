using AutoMapper;
using MealPlanner.Application.Services;
using MealPlanner.Commnication.Request;
using MealPlanner.Domain.Interfaces;

namespace MealPlanner.Application.Patient.UseCases.RegisterPatient
{
    public class RegisterPatientUseCase : IRegisterPatientUseCase
    {
        public readonly IPatientRepository _respository;
        public RegisterPatientUseCase(IPatientRepository respository) => _respository = respository;
        public async Task<Guid> Execute(RequestRegisterPatient request)
        {

            //VALIDAÇÃO

            Validade(request);

            //MAPEAMENTO

            var mapper = new Mapper(new MapperConfiguration(conf =>
            {
                conf.AddProfile(new MealPlannerMapper());
            }));

            var patient = mapper.Map<Domain.Patient>(request);

            var id = await _respository
                .Create(patient);
            //CRIAÇÃO COM BD

            return id;
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
