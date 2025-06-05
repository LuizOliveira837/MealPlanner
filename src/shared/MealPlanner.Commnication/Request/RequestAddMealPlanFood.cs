using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Commnication.Request
{
    public class RequestAddMealPlanFood
    {
        public Guid MealPlanId { get; set; }
        public Guid FoodId { get; set; }
        public double PortionSizeInGrams { get; set; }
    }
}
