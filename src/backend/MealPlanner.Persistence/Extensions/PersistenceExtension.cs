using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Persistence.Extensions
{
    public static class PersistenceExtension
    {

        public static string GetConnectionStringMealPlanner(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("MealPlanner")!;
        }
    }
}
