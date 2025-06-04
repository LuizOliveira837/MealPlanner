using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Commnication.Request
{
    public class RequestRegisterFood
    {
        public string Name { get; set; } = string.Empty;
        public double CaloriesPerGram { get; set; }
    }
}
