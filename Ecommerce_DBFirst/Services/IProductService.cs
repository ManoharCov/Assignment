using Ecommerce_DBFirst.Models;
using Ecommerce_DBFirst.ViewModels;



    public interface IProductService
    {
        List<ProductListVM> GetAllProducts();

        void AddProduct(Product product);
}
