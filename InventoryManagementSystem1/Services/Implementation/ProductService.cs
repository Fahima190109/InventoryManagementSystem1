using InventoryManagementSystem1.Data;
using InventoryManagementSystem1.Models.Product;
using InventoryManagementSystem1.Services.Contacts;
using Microsoft.AspNetCore.Http.HttpResults;

namespace InventoryManagementSystem1.Services.Implementation
{
    public class ProductService : IProduct
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
      
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Product.FindAsync(id);
        }
    }
    
}
