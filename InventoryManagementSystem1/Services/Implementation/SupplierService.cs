using InventoryManagementSystem1.Data;
using InventoryManagementSystem1.Models.Category;
using InventoryManagementSystem1.Models.Supplier;
using InventoryManagementSystem1.Services.Contacts;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem1.Services.Implementation
{
    public class SupplierService : ISupplier
    {
        private readonly ApplicationDbContext _context;

        public SupplierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Supplier> AddSupplierAsync(Supplier supplier)
        {
            _context.Supplier.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<bool> DeleteSupplierByIdAsync(int id)
        {
            var product = await _context.Supplier.FindAsync(id);
            if (product == null) return false;

            _context.Supplier.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Supplier>> GetAllSupplierAsync()
        {
            return await _context.Supplier.ToListAsync(); // Correct as is
        }

        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            return await _context.Supplier.FindAsync(id);
        }

        public async Task<List<Supplier>> SearchSupplierAsync(string searchText)
        {
            IQueryable<Supplier> query = _context.Supplier;
            query = query.Where(p =>
                     p.Name.Contains(searchText));
            return await query.ToListAsync();
        }

        public async Task<bool> UpdateSupplierAsync(Supplier supplier)
        {
            var exists = await _context.Supplier.Where(p => p.Id == supplier.Id).AnyAsync();
            if (!exists) return false;

            _context.Supplier.Update(supplier);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}