using MealPlanner.Commnication;
using MealPlanner.Domain;
using MealPlanner.Domain.Enums;
using MealPlanner.Domain.Interfaces;
using MealPlanner.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MealPlanner.Persistence.Interfaces
{
    public class MealPlanRepository : IMealPlanRepository
    {
        private readonly MealPlannerContext _context;

        public MealPlanRepository(MealPlannerContext context)
        {
            _context = context;
        }
        public async Task<Guid> Create(MealPlan mealPlan)
        {
            await _context
                .MealPlans
                .AddAsync(mealPlan);

            await Update();

            return mealPlan.Id;

        }

        public async Task<Guid> AddMeanPlanFood(MealPlanFood mealPlanFood)
        {
            await _context
                .MealPlanFoods
                .AddAsync(mealPlanFood);

            await Update();

            return mealPlanFood.Id;

        }

        public async Task<IList<PatientMealPlanDetail>> GetMealPlanFoodByPatient(Guid id, int dayOfWeek = 8)
        {
            var query = (from p in _context.Patients
                         join mp in _context.MealPlans on p.Id equals mp.PatientId
                         join mpf in _context.MealPlanFoods on mp.Id equals mpf.MealPlanId
                         join f in _context.Foods on mpf.FoodId equals f.Id
                         where p.Id == id && (mp.DayOfTheWeek == (DayOfTheWeek)dayOfWeek || dayOfWeek == 8)
                         orderby mp.DayOfTheWeek, f.Name
                         select new PatientMealPlanDetail
                         {
                             PatientId = p.Id,
                             PatientName = p.Name,
                             MealPlanId = mp.Id,
                             MealPlanName = mp.Name,
                             DayOfTheWeek = (int)mp.DayOfTheWeek,
                             FoodId = f.Id,
                             FoodName = f.Name,
                             PortionSizeInGrams = mpf.PortionSizeInGrams,
                             CaloriesPerGram = f.CaloriesPerGram,
                             TotalCaloriesPerFood = mpf.PortionSizeInGrams * f.CaloriesPerGram
                         });


            var result = await query.ToListAsync();


            return result;

        }

        public async Task<Guid> Delete(Guid id)
        {
            var mealPlan = await _context
                    .MealPlans
                    .FirstOrDefaultAsync(m => m.Id == id);

            mealPlan.Active = false;

            await Update();

            return mealPlan.Id;
        }

        public async Task<MealPlan> GetById(Guid id)
        {
            return await
                    _context
                    .MealPlans
                    .FirstOrDefaultAsync(m => m.Id == id);

        }

        public async Task Update()
        {
            await _context
                .SaveChangesAsync();
        }
    }
}
