using InventoryManagementSystem1.Models.Category;
using InventoryManagementSystem1.Models.Supplier;

namespace InventoryManagementSystem1.Services.Contacts
{
    public interface ISupplier
    {
        Task<IEnumerable<Supplier>> GetAllSupplierAsync();
        
        Task<Supplier> AddSupplierAsync(Supplier supplier);
    }
}
