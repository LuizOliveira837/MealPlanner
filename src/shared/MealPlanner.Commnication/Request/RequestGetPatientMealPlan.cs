using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Commnication.Request
{
    public class RequestGetPatientMealPlan
    {
        public RequestGetPatientMealPlan(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
