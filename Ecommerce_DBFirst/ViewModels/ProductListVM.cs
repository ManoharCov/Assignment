
namespace Ecommerce_DBFirst.ViewModels
{
    public class ProductListVM
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }

        public int StockQuantity { get; set; }
    }
}

