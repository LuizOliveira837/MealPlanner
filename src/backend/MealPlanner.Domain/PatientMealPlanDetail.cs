using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Commnication
{
    public class PatientMealPlanDetail
    {
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }

        public Guid MealPlanId { get; set; }
        public string MealPlanName { get; set; }
        public int DayOfTheWeek { get; set; }

        public Guid FoodId { get; set; }
        public string FoodName { get; set; }
        public double PortionSizeInGrams { get; set; }
        public double CaloriesPerGram { get; set; }
        public double TotalCaloriesPerFood { get; set; }
    }
}
