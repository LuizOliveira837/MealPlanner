using MealPlanner.Domain;
using MealPlanner.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities.Test.Food.Repositories
{
    public class FoodRepositoryBuilder
    {
        public readonly Mock<IFoodRepository> FoodRepository;

        public FoodRepositoryBuilder()
        {
            FoodRepository = new Mock<IFoodRepository>();

            
        }

        public void Create(MealPlanner.Domain.Food food, Guid guid)
        {
            FoodRepository
                .Setup(e => e.Create(It.IsAny<MealPlanner.Domain.Food>()))
                .ReturnsAsync(guid);
        }
    }
}
