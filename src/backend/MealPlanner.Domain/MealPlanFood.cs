using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Domain
{
    public class MealPlanFood : BaseEntity
    {
        public Guid MealPlanId { get; set; }
        public Guid FoodId { get; set; }
        public double PortionSizeInGrams { get; set; }

        public MealPlan MealPlan { get; set; }
        public Food Food { get; set; }

        [NotMapped]
        public double TotalCalories => PortionSizeInGrams * (Food?.CaloriesPerGram ?? 0);
    }
}
