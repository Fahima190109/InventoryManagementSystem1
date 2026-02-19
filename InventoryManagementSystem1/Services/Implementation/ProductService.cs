using InventoryManagementSystem1.Data;
using InventoryManagementSystem1.Models.Product;
using InventoryManagementSystem1.Services.Contacts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem1.Services.Implementation
{
    public class ProductService : IProduct
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null) return false;

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await _context.Product.ToListAsync();
        }
        

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Product.FindAsync(id);
        }

        public async Task<List<Product>> SearchProductsAsync(string searchText)
        {
            IQueryable<Product> query = _context.Product;
           query = query.Where(p =>
                    p.Name.Contains(searchText) ||
                    p.Description.Contains(searchText));
            
            return await query.ToListAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var exists = await _context.Product.Where(p => p.Id == product.Id).AnyAsync();
            if (!exists) return false;

            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
    
}
