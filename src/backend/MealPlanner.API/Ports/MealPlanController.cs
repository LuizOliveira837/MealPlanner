using MealPlanner.Application.MealPlan.UseCases.AddMealPlanFood;
using MealPlanner.Application.MealPlan.UseCases.RegisterMealPlan;
using MealPlanner.Commnication.Request;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.API.Ports
{

    [ApiController]
    [Route("api/[controller]")]
    public class MealPlanController : Controller
    {


        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IRegisterMealPlanUseCase registerMealPlanUseCase, [FromBody] RequestRegisterMealPlan request)
        {

            var id = await registerMealPlanUseCase.Execute(request);



            return Ok(new { id });
        }

        [HttpPost("MealPlanFood")]
        public async Task<IActionResult> AddFood([FromServices] IAddMealPlanFood addMealPlanFood, [FromBody] RequestAddMealPlanFood request)
        {

            var id = await addMealPlanFood.Execute(request);



            return Ok(new { id });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromServices] IAddMealPlanFood addMealPlanFood, Guid id)
        {




            return Ok(id);
        }







    }
}
