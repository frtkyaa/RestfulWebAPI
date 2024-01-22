using Microsoft.AspNetCore.Mvc.Filters;
using CatalogWebapp.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogWebapp.Filters.ExceptionFilters
{
    public class Shirt_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strShirtId = context.RouteData.Values["id"] as string;
            if ( int.TryParse(strShirtId,out int shirtId))
            {
                if ( !ShirtRepository.ShirtExists(shirtId))
                {
                    context.ModelState.AddModelError("ShirtId", "Shirt doesn't exist anymore.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);

                }
            }
        }
    }
}
