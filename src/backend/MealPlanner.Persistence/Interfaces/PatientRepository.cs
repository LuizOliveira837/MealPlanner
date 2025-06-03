using MealPlanner.Domain;
using MealPlanner.Domain.Interfaces;
using MealPlanner.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Persistence.Interfaces
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MealPlannerContext _context;

        public PatientRepository(MealPlannerContext context)
        {
            _context = context;
        }
        public async Task<Guid> Create(Patient patient)
        {
            await _context.AddAsync(patient);
            await _context.SaveChangesAsync();

            return patient.Id;
        }

        public Task<Guid> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
