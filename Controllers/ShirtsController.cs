using Fliu.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Fliu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {

        private List<Shirt> shirts = new List<Shirt>() {
            new Shirt() { Brand="A", Price=100, Size=7, Gender="Women", ShirtId=1000, ForGym=true},
            new Shirt() { Brand="B", Price=200, Size=9, Gender="Men", ShirtId=2000, ForGym=false},
            new Shirt() { Brand="C", Price=300, Size=8, Gender="Men", ShirtId=3000, ForGym=true},
            new Shirt() { Brand="D", Price=400, Size=12, Gender="Women", ShirtId=4000, ForGym=false},
        };

        /*private List<Shirt> shirts = null;*/
        [HttpGet]
        public IActionResult getAllShirts([FromQuery] int? n)
        {
            if (shirts == null) return StatusCode(StatusCodes.Status500InternalServerError, new { errorMessage =  "No shirts list" });
            if (n == null || n >= shirts.Count) return Ok(shirts);
            if (n < 0) return BadRequest("n must be positive"); 
            var sliced = shirts.Slice(0, n.Value);
            return Ok(sliced); 
        }

    /*    public List<Shirt> GetShirts([FromQuery][Required] int n, [FromHeader(Name = "Dummy-Header")] int dummyHeader)
        {
            return shirts;
        }*/


        [HttpGet("{id}")]
        public IActionResult GetShirtByID([FromRoute] int id)
        {
            if (shirts == null) {
                return StatusCode(StatusCodes.Status500InternalServerError, new { errorMessage = "No shirts list" }); 
            }
            if (id < 0) return BadRequest("ID can't be negative"); 

            Shirt? s = shirts.FirstOrDefault(s => s.ShirtId == id);
            if (s == null) return NotFound("No shirt with this ID exists"); 
            return Ok(s);
        }

        [HttpPost]
        public IActionResult CreateShirt([FromBody][Required] Shirt shirt)
        {
            return Ok("Shirt created"); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShirt([FromRoute][Range(0, int.MaxValue)] int id)
        {
            
            int prevCount = shirts.Count;
            shirts.RemoveAll(s => s.ShirtId == id);
            int newCount = shirts.Count;
            if (prevCount == newCount) return NotFound("No such shirt"); 

            return Ok(new { prevCount, newCount});
        }



        [HttpPut("{id}")]
        public IActionResult UpdateShirt([FromRoute][Range(0, int.MaxValue)] int id, [FromBody][Required] Shirt? data)
        {
            Shirt? found = shirts.Find(s => s.ShirtId == id);
            if (found == null) return NotFound("No such shirt");
            var before = found;
            var after = data;
            return Ok(new { before, after });
        }
    }

}
