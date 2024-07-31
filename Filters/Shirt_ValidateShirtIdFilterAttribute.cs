using Fliu.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Fliu.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Fliu.Filters
{
    public class Shirt_ValidateShirtIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            int? shirtId = context.ActionArguments["id"] as int?;
            if (shirtId.HasValue)
            {
                if (shirtId < 0)
                {
                    context.ModelState.AddModelError("ShirtId", "ShirtId can't be negative");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails); 
                } 
                else if (!ShirtsRepository.ShirtExists(shirtId.Value)) 
                { 
                    context.ModelState.AddModelError("ShirtId", "No such shirt exists");
                    var problemDetails = new ValidationProblemDetails(context.ModelState);
                    context.Result = new NotFoundObjectResult(problemDetails); 
                }
            }
        }
    }
}
