using InventoryManagementSystem1.Data;
using InventoryManagementSystem1.Models.Category;
using InventoryManagementSystem1.Models.Product;
using InventoryManagementSystem1.Services.Contacts;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem1.Services.Implementation
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategoryByIdAsync(int id)
        {
            var product = await _context.Category.FindAsync(id);
            if (product == null) return false;

            _context.Category.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _context.Category.FindAsync(id);
        }

        public async Task<List<Category>> SearchCategoryAsync(string searchText)
        {
            IQueryable<Category> query = _context.Category;
            query = query.Where(p =>
                     p.Name.Contains(searchText));
                     

            return await query.ToListAsync();
        }

        public async  Task<bool> UpdateCategoryAsync(Category category)
        {
            var exists = await _context.Category.Where(p => p.Id == category.Id).AnyAsync();
            if (!exists) return false;

            _context.Category.Update(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
