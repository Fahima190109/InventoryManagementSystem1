using InventoryManagementSystem1.Models.Product;

namespace InventoryManagementSystem1.Services.Contacts
{
    public interface IProduct
    {
        Task<Product?> GetProductByIdAsync(int id);

        //Task<Product?> GetProductByIdAsync(int id);
    }
}
