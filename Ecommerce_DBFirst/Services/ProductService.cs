using Ecommerce_DBFirst.Data;
using Ecommerce_DBFirst.Models;
using Ecommerce_DBFirst.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private readonly EcommerceDBContext _context;
    private readonly IMapper _mapper;

    private readonly ILogger<ProductService> _logger;

    public ProductService(EcommerceDBContext context, IMapper mapper, ILogger<ProductService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public List<ProductListVM> GetAllProducts()
    {
        _logger.LogInformation("ProductService: Fetching all products");

        var products = _context.Products
            .Include(p => p.Category)
            .ToList();


        _logger.LogInformation("ProductService: Retrieved {Count} products", products.Count);

        return _mapper.Map<List<ProductListVM>>(products);
    }

    public void AddProduct(Product product)
    {
        try
        {
            _logger.LogInformation(  "ProductService: Adding product with name {ProductName}", product.Name);

            _context.Products.Add(product);
            _context.SaveChanges();

            _logger.LogInformation(
                "ProductService: Product added successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(   ex, "ProductService: Error occurred while adding product");

            throw;
        }
        ;
    }
}
