using MealPlanner.Domain;
using MealPlanner.Domain.Interfaces;
using MealPlanner.Persistence.Database;
using Microsoft.EntityFrameworkCore;
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
            await Update();

            return patient.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            var patient = await GetById(id);

            patient.Active = false;

            await Update();

            return id;  

        }

        public async Task<Patient> GetById(Guid id)
        {
            return
                await _context.Patients.FirstAsync(x => x.Id == id);


        }

        public async Task Update()
        {
            await _context.SaveChangesAsync();

        }
    }
}
