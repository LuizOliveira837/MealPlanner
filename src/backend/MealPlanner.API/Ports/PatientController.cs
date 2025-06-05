using MealPlanner.Application.Patient.UseCases.DeletePatient;
using MealPlanner.Application.Patient.UseCases.GetPatient;
using MealPlanner.Application.Patient.UseCases.GetPatientMealPlan;
using MealPlanner.Application.Patient.UseCases.RegisterPatient;
using MealPlanner.Commnication;
using MealPlanner.Commnication.Request;
using MealPlanner.Domain;
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
            var id = await registerPatientUseCase.Execute(request);
            return new CreatedAtActionResult("GetById", "Patient", new { id }, request);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromServices] IGetPatientByIdUseCase getPatientByIdUseCase, Guid id)
        {
            var patient = await getPatientByIdUseCase.Execute(new RequestGetPatientById(id));


            return Ok(patient);

        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteById([FromServices] IDeletePatientUseCase deletePatientUseCase, Guid id)
        {
            await deletePatientUseCase.Execute(new RequestDeletePatient(id));
            return Ok();
        }

        [HttpGet("/patients/{id:guid}/mealplans/today")]
        public async Task<ActionResult<ResponsePatientMealPlanTodayDetail>> Put
            ([FromServices] IGetPatientMealPlanUseCase useCase, Guid id)
        {
            var result = await useCase.Execute(new RequestGetPatientMealPlan(id));
            return Ok(result);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id)
        {
            return Ok();
        }




    }
}
