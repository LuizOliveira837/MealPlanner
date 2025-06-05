using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Commnication.Request
{
    public class RequestRegisterMealPlan
    {
        public string Name { get; set; } = string.Empty;
        public Guid PatientId { get; set; }
        public int DayOfTheWeek { get; set; }

    }
}
