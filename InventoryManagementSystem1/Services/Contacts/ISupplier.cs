using InventoryManagementSystem1.Models.Category;
using InventoryManagementSystem1.Models.Supplier;

namespace InventoryManagementSystem1.Services.Contacts
{
    public interface ISupplier
    {
        Task<IEnumerable<Supplier>> GetAllSupplierAsync();
        
        Task<Supplier> AddSupplierAsync(Supplier supplier);
        Task<Supplier> GetSupplierByIdAsync(int id);
        Task<bool> UpdateSupplierAsync(Supplier supplier);
        Task<bool> DeleteSupplierByIdAsync(int id);
        Task<List<Supplier>> SearchSupplierAsync(string searchText);
    }
}
