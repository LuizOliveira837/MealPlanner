using MealPlanner.Commnication.Request;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.API.Ports
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestRegisterPatient request)
        {
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id)
        {
            return Ok();
        }
    }
}
