using Microsoft.AspNetCore.Mvc;
using Ecommerce_CodeFirst_Demo.Data;
using Ecommerce_CodeFirst_Demo.Models;

namespace Ecommerce_CodeFirst_Demo.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            var product = new Product
            {
                Name = "Laptop",
                Price = 50000,
                Quantity = 10
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
