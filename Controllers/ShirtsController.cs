using Fliu.Filters;
using Fliu.Models;
using Fliu.Models.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Fliu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        [HttpGet]
        public IActionResult getAllShirts([FromQuery] int? n)
        {
            if (n < 0) return BadRequest("n must be positive"); 
            List<Shirt> shirts = ShirtsRepository.GetShirts(n);
            return Ok(shirts); 
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtByID([FromRoute] int id)
        {
            Shirt? shirt = ShirtsRepository.GetShirtById(id);
            return Ok(shirt);
        }

        [HttpPost]
        public IActionResult CreateShirt([FromBody][Required] Shirt shirt)
        {
            return Ok("Shirt created"); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShirt([FromRoute][Range(0, int.MaxValue)] int id)
        {
            return Ok("Shirt deleted");
        }



        [HttpPut("{id}")]
        public IActionResult UpdateShirt([FromRoute][Range(0, int.MaxValue)] int id, [FromBody][Required] Shirt? data)
        {
            return Ok("Shirt updated");
        }
    }

}
