using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem1.Models.Category
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
