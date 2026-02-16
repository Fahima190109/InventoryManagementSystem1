using InventoryManagementSystem1.Models.Product;
using System.Linq;

namespace InventoryManagementSystem1.Repository
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                CategoryId = 1,
                Description = "Laptop Description",
                Name = "Laptop",
                Price = 100000,
                Quantity = 5,
            },
            new Product
            {
                Id = 2,
                CategoryId = 1,
                Description = "Mouse Description",
                Name = "Mouse",
                Price = 500,
                Quantity = 4,
            },
            new Product
            {
                Id = 3,
                CategoryId = 2,
                Description = "Keyboard Description",
                Name = "Keyboard",
                Price = 1000,
                Quantity = 10,
            },
        };

        public static List<Product> GetAll()
        {
            return _products;
        }

        public static Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public static void Add(Product product)
        {
            // Auto-generate ID if needed
            if (product.Id == 0)
            {
                product.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            }
            _products.Add(product);
        }

        public static void Update(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
                existingProduct.CategoryId = product.CategoryId;
            }
        }
        public static void UpdateProductName(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id
            == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;    
            }
        }
        public static void Delete(int id)
        {
            var existingProduct = GetById(id);
            if (existingProduct != null)
            {
                _products.Remove(existingProduct);
            }
        }
    }
}