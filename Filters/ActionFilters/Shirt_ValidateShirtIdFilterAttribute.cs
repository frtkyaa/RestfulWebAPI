using CatalogWebapp.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CatalogWebapp.Filters.ActionFilters
{
    public class Shirt_ValidateShirtIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var ShirtId = context.ActionArguments["id"] as int?;

            if (ShirtId.HasValue)
            {
                if (ShirtId.Value <= 0)
                {
                    context.ModelState.AddModelError("ShirtId", "Shirt is invalid");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);

                }

                else if (!ShirtRepository.ShirtExists(ShirtId.Value))
                {
                    context.ModelState.AddModelError("ShirtId", "Shirt doesn't exist.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}




