using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Exception
{
    public class ExceptionOnValidation : MealPlannerExceptions
    {
        public IList<string> ErrorMensages { get; set; }
        public ExceptionOnValidation(IList<string> errorMensages)
        {
            this.ErrorMensages = errorMensages;
        }

    
    }
}
