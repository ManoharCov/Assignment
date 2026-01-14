using Ecommerce_DBFirst.Data;
using Ecommerce_DBFirst.Models;
using Microsoft.AspNetCore.Mvc;

public class CategoryController : Controller
{
    private readonly EcommerceDBContext _context;

    public CategoryController(EcommerceDBContext context)
    {
        _context = context;
    }

    // LIST
    public IActionResult Index()
    {
        return View(_context.Categories.ToList());
    }

    // CREATE - GET
    public IActionResult Create()
    {
        return View();
    }

    // CREATE - POST
    [HttpPost]
    public IActionResult Create(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    // EDIT - GET
    public IActionResult Edit(int id)
    {
        return View(_context.Categories.Find(id));
    }

    // EDIT - POST
    [HttpPost]
    public IActionResult Edit(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    // DELETE - GET (Confirmation)
    public IActionResult Delete(int id)
    {
        var category = _context.Categories.Find(id);
        return View(category);
    }

    // DELETE - POST (Actual delete)
    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var category = _context.Categories.Find(id);
        _context.Categories.Remove(category);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}
