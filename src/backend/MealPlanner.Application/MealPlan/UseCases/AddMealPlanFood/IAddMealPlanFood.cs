using MealPlanner.Commnication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.MealPlan.UseCases.AddMealPlanFood
{
    public interface IAddMealPlanFood
    {
        public Task<Guid> Execute(RequestAddMealPlanFood request);

        public Task Validade(RequestAddMealPlanFood request);



    }
}
