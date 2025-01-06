using API.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Net.Controllers
{
    [Route("products")]  // Route 
    public class ProductController : Controller
    {
        private readonly DbtestContext _context;

        public ProductController(DbtestContext context)
        {
            _context = context;
        }




        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _context.Products.Take(10).ToList();
            return Ok(products);

        }


        [HttpGet("new")]
        public IActionResult GetProductNew()
        {
            var products = _context.Products.ToList()
                .OrderByDescending(p => p.CreateAt).Take(10);
            return Ok(products);
        }

        [HttpGet("best_seller")]
        public IActionResult GetProductBestSeller()
        {
            var products = _context.Products.
                Include(p => p.OrderDetails)
                .ToList()
                .OrderByDescending(p => p.OrderDetails.Count())
                .Take(10);
            return Ok(products);
        }

        [HttpGet("highest_price")]
        public IActionResult GetProductHighestPrice()
        {
            var products = _context.Products
                .ToList()

                .OrderByDescending(p => p.Price).Take(10);
            return Ok(products);
        }



        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            // Lấy một sản phẩm theo ID
            var product = _context.Products
             .Include(p => p.Subimages)     
             .Include(p => p.Subcategory)
              .Include(p => p.Specification)     
             .FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }

      


    }
}
