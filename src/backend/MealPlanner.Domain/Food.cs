using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Domain
{
    public class Food : BaseEntity
    {
        public Food(string name, double caloriesPerGram)
        {
            Name = name;
            CaloriesPerGram = caloriesPerGram;
        }

        public string Name { get; set; } = string.Empty;
        public double CaloriesPerGram { get; set; }

    }
}
