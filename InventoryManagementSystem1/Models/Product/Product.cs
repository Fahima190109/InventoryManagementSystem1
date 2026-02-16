using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem1.Models.Product
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        
    }   
}
