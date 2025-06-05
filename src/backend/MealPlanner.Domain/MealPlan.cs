using MealPlanner.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Domain
{
    public class MealPlan : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public DayOfTheWeek DayOfTheWeek { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        
        public ICollection<MealPlanFood> MealPlanFoods { get; set; } 
    }
}
