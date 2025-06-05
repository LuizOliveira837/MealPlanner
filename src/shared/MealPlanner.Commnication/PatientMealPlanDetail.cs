using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Commnication
{
    public class ResponsePatientMealPlanTodayDetail
    {
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }
        public IList<MealPlanInfo> MealPlanInfos { get; set; }





    }

    public class MealPlanInfo
    {
        public Guid MealPlanId { get; set; }
        public string MealPlanName { get; set; }
        public string DayOfTheWeek { get; set; }

        public IList<FoodCalories> FoodCalories { get; set; }

    }
    public class FoodCalories
    {
        public Guid FoodId { get; set; }
        public string FoodName { get; set; }
        public double PortionSizeInGrams { get; set; }
        public double CaloriesPerGram { get; set; }
        public double TotalCaloriesPerFood { get; set; }
    }
}
