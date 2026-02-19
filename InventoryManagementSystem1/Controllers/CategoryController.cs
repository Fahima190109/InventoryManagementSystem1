using InventoryManagementSystem1.Data;
using InventoryManagementSystem1.Models.Category;
using InventoryManagementSystem1.Models.Product;
using InventoryManagementSystem1.Services.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        //private readonly IProduct _product;
        private readonly ICategory _category;
        //private object _reader;

        public CategoryController(ApplicationDbContext applicationDbContext, ICategory category)
        {
            _applicationDbContext = applicationDbContext;
            _category = category;
            // _product = product;
        }
        // public async Task<IActionResult> Index()
        // {
        //     var products = await _reader.GetAllProductAsync();
        //     return View(products);
        // }
        public async Task<IActionResult> Index()
        {
            //Service->student Data fatch ->student model
            //var products = ProductRepository.GetAll();
            //var products = _applicationDbContext.Product.ToList();
            var Categories = await _category.GetAllCategoryAsync();
            // var products = await _product.SearchProductsAsync(searchText);
            return View(Categories);
            //return View();
        }
        public IActionResult Create()
        {
            //ProductRepository.Add(product);
            //return RedirectToAction("Index");
            //how got viewbag
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            //_applicationDbContext.Add(product);
            //_applicationDbContext.SaveChanges();
            await _category.AddCategoryAsync(category);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            //var product = await _applicationDbContext.Product.FindAsync(id); 
            // ✅ await added
            var category = await _category.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            //PopulateDropdowns();
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            //if(id != product.Id) return NotFound();
            //_applicationDbContext.Update(product);
            //_applicationDbContext.SaveChanges();
            bool exits = await _category.UpdateCategoryAsync(category);
            return exits == true ? RedirectToAction("Index") : NotFound();
        }
        public async Task<IActionResult> Delete(int id)
        {
            //var product = await _applicationDbContext.Product.FindAsync(id);
            var products = await _category.GetCategoryByIdAsync(id);
            return View(products);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var product = await _applicationDbContext.Product.FindAsync(id);
            //var products = await _product.GetProductByIdAsync(id);
            bool deleted = await _category.DeleteCategoryByIdAsync(id);
            if (!deleted) return NotFound();

            //if (products != null)
            //{
            //    _applicationDbContext.Product.Remove(products);
            //    _applicationDbContext.SaveChanges();
            //}
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Index(string searchText)
        {
            var products = await _category.SearchCategoryAsync(searchText);
            return View(products);
        }
    }
}
