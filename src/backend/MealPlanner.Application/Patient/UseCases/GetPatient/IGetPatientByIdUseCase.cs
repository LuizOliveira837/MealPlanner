using MealPlanner.Commnication;
using MealPlanner.Commnication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.Patient.UseCases.GetPatient
{
    public interface IGetPatientByIdUseCase
    {
        public Task<ResponseGetPatientById> Execute(RequestGetPatientById id);

        public void Validade(RequestGetPatientById id);
    }
}
