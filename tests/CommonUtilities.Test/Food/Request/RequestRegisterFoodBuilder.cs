using Bogus;
using MealPlanner.Commnication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities.Test.Food.Request
{
    public static class RequestRegisterFoodBuilder
    {
        public static IList<string> Foods = new List<string>() {

            "Arroz",
            "Feijão",
            "Maçã",
        };

        public static RequestRegisterFood Build()
        {
            var faker = new Faker<RequestRegisterFood>()
                .RuleFor(rp => rp.Name, (f) => f.PickRandom(Foods))
                .RuleFor(rp => rp.CaloriesPerGram, (f) => f.Random.Int(10, 10000));

            return faker;
        }
    }
}
