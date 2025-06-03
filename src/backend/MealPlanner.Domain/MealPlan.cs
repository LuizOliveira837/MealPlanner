using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Domain
{
    public class MealPlan : BaseEntity
    {

        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public ICollection<MealPlanFood> MealPlanFoods { get; set; }
    }
}
