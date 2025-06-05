using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Commnication.Request
{
    public class RequestGetPatientById
    {

        public RequestGetPatientById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

    }
}

