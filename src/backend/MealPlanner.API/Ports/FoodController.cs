using MealPlanner.Application.Food.UseCases;
using MealPlanner.Commnication.Request;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.API.Ports
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : Controller
    {


        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IRegisterFoodUseCase registerFoodUseCase, [FromBody] RequestRegisterFood request)
        {
            var id = await registerFoodUseCase.Execute(request);

            return Ok(id);
        }

    }
}
