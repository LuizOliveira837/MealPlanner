using MealPlanner.Domain;
using MealPlanner.Domain.Interfaces;
using MealPlanner.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Persistence.Interfaces
{
    public class FoodRepository : IFoodRepository
    {
        private readonly MealPlannerContext _context;

        public FoodRepository(MealPlannerContext context)
        {
            _context = context;
        }
        public async Task<Guid> Create(Food food)
        {
            await _context
                .Foods
                .AddAsync(food);

            await Update();

            return food.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            var food = await GetById(id);

            food.Active = false;

            await Update();

            return id;
        }

        public async Task<Food> GetById(Guid id)
        {
            var food = await _context
                .Foods
                .FirstOrDefaultAsync(x => x.Id == id);

            return food;
        }

        public async Task Update()
        {
            await _context
                .SaveChangesAsync();
        }
    }
}
