using Ecommerce_DBFirst.Data;
using Ecommerce_DBFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class ProductController : Controller
{
    private readonly EcommerceDBContext _context;

    public ProductController(EcommerceDBContext context)
    {
        _context = context;
    }

    // LIST
    public IActionResult Index()
    {
        var products = _context.Products
            .Include(p => p.Category)
            .ToList();

        return View(products);
    }

    // DETAILS
    public IActionResult Details(int id)
    {
        var product = _context.Products
            .Include(p => p.Category)
            .FirstOrDefault(p => p.ProductId == id);

        return View(product);
    }

    // CREATE - GET
    public IActionResult Create()
    {
        ViewData["CategoryList"] = new SelectList(
            _context.Categories.ToList(),
            "CategoryId",
            "CategoryName"
        );

        return View();
    }

    // CREATE - POST
    [HttpPost]
    public IActionResult Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    // EDIT - GET
    public IActionResult Edit(int id)
    {
        var product = _context.Products.Find(id);

        ViewData["CategoryList"] = new SelectList(
            _context.Categories.ToList(),
            "CategoryId",
            "CategoryName",
            product.CategoryId
        );

        return View(product);
    }

    // EDIT - POST
    [HttpPost]
    public IActionResult Edit(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    // DELETE
    public IActionResult Delete(int id)
    {
        var product = _context.Products.Find(id);

        _context.Products.Remove(product);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}
