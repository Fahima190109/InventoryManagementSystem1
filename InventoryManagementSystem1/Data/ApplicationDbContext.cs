using InventoryManagementSystem1.Models.Category;
using InventoryManagementSystem1.Models.Product;
using InventoryManagementSystem1.Models.Supplier;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSet properties for your entities here
        // public DbSet<Product> Products { get; set; }
        public DbSet<Product> Product {  get; set; }
        public DbSet<Category> Category { get; set; }
        //public DbSet<Supplier> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
    }
}
