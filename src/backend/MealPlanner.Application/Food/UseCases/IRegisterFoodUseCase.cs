using MealPlanner.Commnication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.Food.UseCases
{
    public interface IRegisterFoodUseCase
    {

        public Task Execute(RequestRegisterFood request);

        public Task Validade(RequestRegisterFood request);
    }
}
