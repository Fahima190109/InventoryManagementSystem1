using InventoryManagementSystem1.Data;
using InventoryManagementSystem1.Models.Category;
using InventoryManagementSystem1.Models.Supplier;
using InventoryManagementSystem1.Services.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem1.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        //private readonly IProduct _product;
        private readonly ISupplier _supplier;
        //private object _reader;

        public SupplierController(ApplicationDbContext applicationDbContext, ISupplier supplier)
        {
            _applicationDbContext = applicationDbContext;
            _supplier = supplier;
            // _product = product;
        }
        public async Task<IActionResult> Index()
        {
            var Categories = await _supplier.GetAllSupplierAsync();
            // var products = await _product.SearchProductsAsync(searchText);
            return View(Categories);
            //return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            //_applicationDbContext.Add(product);
            //_applicationDbContext.SaveChanges();
            await _supplier.AddSupplierAsync(supplier);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            //var product = await _applicationDbContext.Product.FindAsync(id); 
            // ✅ await added
            var category = await _supplier.GetSupplierByIdAsync(id);
            if (category == null) return NotFound();
            //PopulateDropdowns();
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Supplier supplier)
        {
            //if(id != product.Id) return NotFound();
            //_applicationDbContext.Update(product);
            //_applicationDbContext.SaveChanges();
            bool exits = await _supplier.UpdateSupplierAsync(supplier);
            return exits == true ? RedirectToAction("Index") : NotFound();
        }
        public async Task<IActionResult> Delete(int id)
        {
            //var product = await _applicationDbContext.Product.FindAsync(id);
            var products = await _supplier.GetSupplierByIdAsync(id);
            return View(products);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var product = await _applicationDbContext.Product.FindAsync(id);
            //var products = await _product.GetProductByIdAsync(id);
            bool deleted = await _supplier.DeleteSupplierByIdAsync(id);
            if (!deleted) return NotFound();

            //if (products != null)
            //{
            //    _applicationDbContext.Product.Remove(products);
            //    _applicationDbContext.SaveChanges();
            //}
            return RedirectToAction("Index");

        }
        //ami jodi akta suppli id k delete korte cai tahole seta kora jai nak
        //karon seta product foreign key
        //aki product barbart add korle search gia oi product lekle oi product r paoa jai nah
        [HttpPost]
        public async Task<IActionResult> Index(string searchText)
        {
            var products = await _supplier.SearchSupplierAsync(searchText);
            return View(products);
        }
    }
}
