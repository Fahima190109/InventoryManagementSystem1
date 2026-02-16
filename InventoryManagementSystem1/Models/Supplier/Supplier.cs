using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem1.Models.Supplier
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public string Country {  get; set; }
        public ICollection<Product.Product> Products { get; set; }
    }
}
