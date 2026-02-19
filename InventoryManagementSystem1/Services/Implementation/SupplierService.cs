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

        public async Task<IEnumerable<Supplier>> GetAllSupplierAsync()
        {
            return await _context.Supplier.ToListAsync();
        }
    }
}
