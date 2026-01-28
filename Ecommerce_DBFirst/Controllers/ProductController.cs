using AutoMapper;
using Ecommerce_DBFirst.Data;
using Ecommerce_DBFirst.Models;
using Ecommerce_DBFirst.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

[Authorize]
[Route("products")]
public class ProductController : Controller
{
    private readonly EcommerceDBContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(EcommerceDBContext context, IMapper mapper, ILogger<ProductController> logger, IProductService productService)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
        _productService = productService;
    }

    // GET: /products
    [HttpGet("")]
    public IActionResult Index()
    {
        _logger.LogInformation("Fetching product list");

        var products = _context.Products.Include(p => p.Category).ToList();
        var vm = _mapper.Map<List<ProductListVM>>(products);
        return View(vm);
    }

    // GET: /products/details/5
    [HttpGet("details/{id}")]
    public IActionResult Details(int id)
    {
        var product = _context.Products
            .Include(p => p.Category)
            .FirstOrDefault(p => p.ProductId == id);

        return View(product);
    }

    // GET: /products/create
    [Authorize(Roles = "Admin")]
    [HttpGet("create")]
    public IActionResult Create()
    {
        ViewData["CategoryList"] = new SelectList(
            _context.Categories,
            "CategoryId",
            "CategoryName"
        );
        return View();
    }

    // POST: /products/create
    [Authorize(Roles = "Admin")]
    [HttpPost("create")]
    public IActionResult Create(Product product)
    {

        if(!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid product data submitted");
            return View(product);
        }
        try {
            _context.Products.Add(product);
            _context.SaveChanges();

            TempData["Success"] = "Product added successfully";
            return RedirectToAction(nameof(Index));
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error adding product");
            throw;
        }

    }

    // GET: /products/edit/5
    [Authorize(Roles = "Admin")]
    [HttpGet("edit/{id}")]
    public IActionResult Edit(int id)
    {
        var product = _context.Products.Find(id);

        ViewData["CategoryList"] = new SelectList(
            _context.Categories,
            "CategoryId",
            "CategoryName",
            product.CategoryId
        );

        return View(product);
    }

    // POST: /products/edit
    [Authorize(Roles = "Admin")]
    [HttpPost("edit")]
    public IActionResult Edit(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    // GET: /products/delete/5
    [Authorize(Roles = "Admin")]
    [HttpGet("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var product = _context.Products.Find(id);
        _context.Products.Remove(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    // GET: /products/search
    [HttpGet("search")]
    public IActionResult Search(string text)
    {
        var products = _context.Products
            .Include(p => p.Category)
            .Where(p => string.IsNullOrEmpty(text) || p.Name.Contains(text))
            .ToList();

        var vm = _mapper.Map<List<ProductListVM>>(products);
        return PartialView("_ProductList", vm);
    }


// /products/sort/price
[HttpGet("sort/price")]
    public IActionResult SortByPrice()
    {
        var products = _context.Products
            .Include(p => p.Category)
            .OrderBy(p => p.Price)
            .ToList();

        var vm = _mapper.Map<List<ProductListVM>>(products);

        return View("Index", vm);
    }



}
