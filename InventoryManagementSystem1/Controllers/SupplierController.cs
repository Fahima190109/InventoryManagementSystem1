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
        //public IActionResult Create()
        //{
        //   return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(Supplier supplier)
        //{
        //    //_applicationDbContext.Add(product);
        //    //_applicationDbContext.SaveChanges();
        //    await _supplier.AddSupplierAsync(supplier);
        //    return RedirectToAction("Index");
        //}
    }
}
