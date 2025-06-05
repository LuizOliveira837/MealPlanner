using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Commnication.Request
{
    public class RequestRegisterPatient
    {
        public string Name { get; set; } = string.Empty;
        public double Weight { get; set; }
        public double Height { get; set; }
    }
}
