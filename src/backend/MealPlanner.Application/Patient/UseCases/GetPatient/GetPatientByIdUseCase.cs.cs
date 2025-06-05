using AutoMapper;
using MealPlanner.Commnication;
using MealPlanner.Commnication.Request;
using MealPlanner.Domain.Interfaces;
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
                throw new Exception("Paciente não encontrado");

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
                throw new Exception(result
                    .Errors[0].ToString());
            }
        }
    }
}
