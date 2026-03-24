using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        static List<string> products = new List<string>
        {
            "1.Manzanas", "2.Tomates", "3.Zanahorias", 
            "4.Coco", "5.Pepinos", "6.lechuga"
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id < 0 || id >= products.Count)
                return NotFound();

            return Ok(products[id]);
        }
    }
}
