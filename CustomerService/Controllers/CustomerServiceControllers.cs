using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerService : ControllerBase
    {
        static List<string> customers = new List<string>
        {
            "JUAN", "PEDRO", "KEYLA", "JHOISY", 
            "ANA", "SAMUEL"
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id < 0 || id >= customers.Count)
                return NotFound();

            return Ok(customers[id]);
        }
    }
}
