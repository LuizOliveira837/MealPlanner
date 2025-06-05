using MealPlanner.Commnication;
using MealPlanner.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace MealPlanner.API.Filter
{
    public class MealPlannerExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is MealPlannerExceptions) HandleProjectException(context);

           



        }



        public void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is ExceptionOnValidation)
            {

                var exception = (ExceptionOnValidation)context.Exception;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorMensages));

            }
        }



        
    
    }
}
