using InventoryManagementSystem1.Models.Product;

namespace InventoryManagementSystem1.Services.Contacts
{
    public interface IProduct
    {
        Task<Product?> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product> AddProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductByIdAsync(int id);
        Task<List<Product>> SearchProductsAsync(string searchText);
        //Task<Product?> GetProductByIdAsync(int id);
    }
}
