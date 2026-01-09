using Microsoft.AspNetCore.Mvc;
using MVC_Assignment.Models;

namespace MVC_Assignment.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
        {
            private static readonly List<Product> products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 50000, Description = "High performance laptop" },
            new Product { Id = 2, Name = "Mobile", Price = 20000, Description = "Android smartphone" },
            new Product { Id = 3, Name = "Headphones", Price = 3000, Description = "Noise cancelling" }
        };

        // GET: /Product
        [HttpGet("")]
        public IActionResult Index()
            {
                return View(products);
            }

        // GET: /Product/Details/1
        [HttpGet("Details/{id:int}")]
        public IActionResult Details(int id)
            {
                var product = products.FirstOrDefault(p => p.Id == id);
                return View(product);
            }
        }

}
