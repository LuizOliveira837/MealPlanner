using MealPlanner.Application.Patient.UseCases.DeletePatient;
using MealPlanner.Application.Patient.UseCases.RegisterPatient;
using MealPlanner.Commnication.Request;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.API.Ports
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Post
            ([FromServices] IRegisterPatientUseCase registerPatientUseCase
            , [FromBody] RequestRegisterPatient request)
        {
            await registerPatientUseCase.Execute(request);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteById([FromServices] IDeletePatientUseCase deletePatientUseCase, Guid id)
        {
            await deletePatientUseCase.Execute(new RequestDeletePatient(id));
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id)
        {
            return Ok();
        }
    }
}
