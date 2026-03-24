using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderService : ControllerBase
    {
        static List<string> orders = new List<string>
        {
            "1 Order", "2 order", "3 Order", "4 Order",
            "5 Order", "6 order"
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id < 0 || id >= orders.Count)
                return NotFound();

            return Ok(orders[id]);
        }
    }
}
