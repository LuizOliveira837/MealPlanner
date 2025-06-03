using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Domain.Interfaces
{
    public interface IPatientRepository
    {

        public Task<Guid> Create(Patient patient); 
        public Task<Patient> GetById(Guid id); 
        public Task<Guid> Delete(Guid id);
        public Task Update();

    }
}
