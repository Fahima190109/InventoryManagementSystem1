using InventoryManagementSystem1.Models.Category;
using InventoryManagementSystem1.Models.Product;

namespace InventoryManagementSystem1.Services.Contacts
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> GetCategoryByIdAsync(int id);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryByIdAsync(int id);
        Task<List<Category>> SearchCategoryAsync(string searchText);
    }
}
