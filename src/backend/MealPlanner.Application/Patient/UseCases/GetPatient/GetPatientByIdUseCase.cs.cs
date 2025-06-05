using AutoMapper;
using MealPlanner.Commnication.Request;
using MealPlanner.Commnication.Response;
using MealPlanner.Domain.Interfaces;
using MealPlanner.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.Patient.UseCases.GetPatient
{
    public class GetPatientByIdUseCase : IGetPatientByIdUseCase
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public GetPatientByIdUseCase(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseGetPatientById> Execute(RequestGetPatientById request)
        {
            Validade(request);

            var patient = await _repository.GetById(request.Id);

            if (patient == null)
            {
                throw new ExceptionOnValidation(new List<string>()
                {
                    MealPlannerResource.PATIENT_NOTFOUNT
                });

            }

            var response = _mapper.Map<ResponseGetPatientById>(patient);

            return response;


        }

        public void Validade(RequestGetPatientById id)
        {
            var validator = new ValidateRequestGetPatientById();


            var result = validator.Validate(id);


            if (!result.IsValid)
            {
                var erros = result.Errors.Select(e => e.ErrorMessage.ToString()).ToList();
                throw new ExceptionOnValidation(erros);
            }
        }
    }
}
