using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Domain.Interfaces
{
    public interface IFoodRepository
    {
        public Task<Guid> Create(Food food);
        public Task<Food> GetById(Guid id);
        public Task<Guid> Delete(Guid id);
        public Task Update();
    }
}
