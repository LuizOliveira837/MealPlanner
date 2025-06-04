using MealPlanner.Commnication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.Patient.UseCases.DeletePatient
{
    public interface IDeletePatientUseCase
    {

        public Task Execute(RequestDeletePatient request);

        public void Validade(RequestDeletePatient request);
    }



}
