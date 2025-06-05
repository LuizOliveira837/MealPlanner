using MealPlanner.Commnication.Request;
using MealPlanner.Domain.Interfaces;
using MealPlanner.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.Patient.UseCases.DeletePatient
{
    public class DeletePatientUseCase : IDeletePatientUseCase
    {
        private readonly IPatientRepository _repository;

        public DeletePatientUseCase(IPatientRepository repository)
        {
            _repository = repository;
        }
        public async Task Execute(RequestDeletePatient request)
        {
            //validação

            Validade(request);

            await _repository.Delete(request.Id);




        }

        public void Validade(RequestDeletePatient request)
        {
            var validator = new ValidateRequestDeletePatient();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var erros = result.Errors.Select(e => e.ErrorMessage.ToString()).ToList();
                throw new ExceptionOnValidation(erros);
            }
        }
    }
}
