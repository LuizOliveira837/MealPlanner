using MealPlanner.Commnication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Domain.Interfaces
{
    public interface IMealPlanRepository
    {
        public Task<Guid> Create(MealPlan mealPlan);
        public Task<Guid> AddMeanPlanFood(MealPlanFood mealPlanFood);
        public Task<IList<PatientMealPlanDetail>> GetMealPlanFoodByPatient(Guid id, int dayOfWeek);
        public Task<MealPlan> GetById(Guid id);
        public Task<Guid> Delete(Guid id);
        public Task Update();
    }
}
