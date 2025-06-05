using MealPlanner.Commnication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.MealPlan.UseCases.RegisterMealPlan
{
    public interface IRegisterMealPlanUseCase
    {
        public Task<Guid> Execute(RequestRegisterMealPlan request);

        public Task Validate(RequestRegisterMealPlan request);

    }
}
