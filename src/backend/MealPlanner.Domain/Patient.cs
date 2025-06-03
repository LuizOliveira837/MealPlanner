using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Domain
{
    public class Patient : BaseEntity
    {
        public Patient(string name, double weight, double height)
        {
            Name = name;
            Weight = weight;
            Height = height;
        }

        public string Name { get; set; } = string.Empty;
        public double Weight { get; set; }
        public double Height { get; set; }

        public ICollection<MealPlan> MealPlans { get; set; }




    }
}
