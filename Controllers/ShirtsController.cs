
using CatalogWebapp.Filters;
using CatalogWebapp.Filters.ActionFilters;
using CatalogWebapp.Filters.ExceptionFilters;
using CatalogWebapp.Models;
using CatalogWebapp.Models.Repositories;
using Microsoft.AspNetCore.Http.HttpResults; 
using Microsoft.AspNetCore.Mvc; 

namespace CatalogWebapp.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] 
    public class ShirtsController : ControllerBase  
    {

        [HttpGet] 
        public IActionResult GetShirts()
        {
            return Ok(ShirtRepository.GetShirts());// Status Code : 200
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {
            
            return Ok(ShirtRepository.GetShirtById(id)); // Status Code : 200

        }

        [HttpPost]
        [Shirt_ValidateCreateShirtFilter]
        public IActionResult CreateShirt([FromBody]Shirt shirt)
        {
            ShirtRepository.AddShirt(shirt);

            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.ShirtId },
                shirt);
        }

        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_HandleUpdateExceptionsFilter]
        public IActionResult UpdateShirt(int id,Shirt shirt)
        {
               ShirtRepository.UpdateShirt(shirt);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult DeleteShirt(int id)
        {
            var shirt = ShirtRepository.GetShirtById(id);
            ShirtRepository.DeleteShirt(id);

            return Ok(shirt);
        }
    }
}






