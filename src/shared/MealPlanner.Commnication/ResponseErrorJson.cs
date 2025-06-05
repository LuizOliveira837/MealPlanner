using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Commnication
{
    public class ResponseErrorJson
    {
        public ResponseErrorJson(ICollection<string> erros)
        {
            Erros = erros;
        }

        public ICollection<string> Erros { get; set; }
    }
}
