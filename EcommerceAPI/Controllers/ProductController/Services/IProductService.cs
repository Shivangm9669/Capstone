using EcommerceAPI.Models;

namespace EcommerceAPI.Controllers.ProductController.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProductById(Guid productId);
        Task<Product> CreateProduct(Product product);
        Task<bool> UpdateProduct(Guid productId, Product updatedProduct);
        Task<bool> DeleteProduct(Guid productId);
    }
}
