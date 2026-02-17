//using InventoryManagementSystem1.Data;
//using InventoryManagementSystem1.Models;
//using InventoryManagementSystem1.Models.Product;
//using InventoryManagementSystem1.Repository;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore; // For async operations like ToListAsync()
//using System.Diagnostics;

//namespace InventoryManagementSystem1.Controllers
//{
//    public class ProductController : Controller
//    {
//        private readonly ApplicationDbContext _applicationDbContext;

//        public ProductController(ApplicationDbContext applicationDbContext)
//        {
//            _applicationDbContext = applicationDbContext;
//        }

//        // GET: Product
//        public IActionResult Index()
//        {
//            var products = ProductRepository.GetAll(); // Keep as is for now
//            return View(products);
//        }

//        // GET: Product/Details/5
//        public IActionResult Details(int id)
//        {
//            var product = _applicationDbContext.Product.Find(id);
//            if (product == null) return NotFound();
//            return View(product);
//        }

//        // GET: Product/Create
//        public IActionResult Create()
//        {
//            PopulateDropdowns();
//            return View();
//        }

//        // POST: Product/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(Product product)
//        {
//            if (ModelState.IsValid)
//            {
//                _applicationDbContext.Add(product);
//                await _applicationDbContext.SaveChangesAsync(); // ✅ Async save
//                return RedirectToAction(nameof(Index));
//            }
//            // If model invalid, repopulate dropdowns and return view with errors
//            PopulateDropdowns();
//            return View(product);
//        }

//        // GET: Product/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null) return NotFound();

//            var product = await _applicationDbContext.Product.FindAsync(id);
//            if (product == null) return NotFound();

//            PopulateDropdowns();
//            return View(product);
//        }

//        // POST: Product/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, Product product)
//        {
//            if (id != product.Id) return NotFound();

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _applicationDbContext.Update(product);
//                    await _applicationDbContext.SaveChangesAsync(); // ✅ Async save
//                    return RedirectToAction(nameof(Index));
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ProductExists(product.Id))
//                        return NotFound();
//                    throw;
//                }
//            }
//            // If model invalid, repopulate dropdowns and return view
//            PopulateDropdowns();
//            return View(product);
//        }

//        private bool ProductExists(int id)
//        {
//            return _applicationDbContext.Product.Any(e => e.Id == id);
//        }

//        private void PopulateDropdowns()
//        {
//            // Fetch categories and suppliers synchronously (or use ToListAsync if you make this method async)
//            var categories = _applicationDbContext.Category.ToList();
//            var suppliers = _applicationDbContext.Supplier.ToList();

//            ViewBag.Categories = new SelectList(categories, "Id", "Name");
//            ViewBag.Suppliers = new SelectList(suppliers, "Id", "Name");
//        }

//        // Other actions (Privacy, Error) remain unchanged...
//        public IActionResult Privacy() => View();

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
using InventoryManagementSystem1.Data;
using InventoryManagementSystem1.Models;
using InventoryManagementSystem1.Models.Product;

//using InventoryManagementSystem1.Models.Category;
//using InventoryManagementSystem1.Models.Product;
//using InventoryManagementSystem1.Models.Supplier;
using InventoryManagementSystem1.Repository;
using InventoryManagementSystem1.Services.Contacts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;

namespace InventoryManagementSystem1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IProduct _product;
        //private object _reader;

        public ProductController(ApplicationDbContext applicationDbContext, IProduct product)
        {
            _applicationDbContext = applicationDbContext;
            _product = product;
        }

        public IActionResult Index()
        {
            //Service->student Data fatch ->student model
            //var products = ProductRepository.GetAll();
            var products = _applicationDbContext.Product.ToList();
            return View(products);
            //return View();
        }
        //public IActionResult Details(int id)
        //{
        //    var products = ProductRepository.GetById(id);
        //    return View(products);
        //}
        public async Task<IActionResult>  Details(int id)
        {
            //var products = _applicationDbContext.Product.Find(id);
            var products = await _product.GetProductByIdAsync(id);
            if (products == null) return NotFound();
            return View(products);
        }
        //[HttpPost] request nia kotha Ab
        public IActionResult Create()
        {
            //ProductRepository.Add(product);
            //return RedirectToAction("Index");
            //how got viewbag
            PopulateDropdowns();
            return View();
        }

        private void PopulateDropdowns()
        {
            //var categories = new List<Category>
            //{
            //    new Category
            //    {
            //        Id = 1,
            //        Name = "Electronics",

            //    },

            //    new Category
            //    {
            //        Id = 2,
            //        Name = "Mechanical",
            //    }
            //};

            //var suppliers = new List<Supplier>
            //{
            //    new Supplier
            //    {
            //        Id=1,
            //        Name="Supplier 1",
            //        ContactInfo="USA Test Contact 1",
            //        Country="USA",
            //    },
            //     new Supplier
            //    {
            //        Id=2,
            //        Name="Supplier 2",
            //        ContactInfo="UK Test Contact 2",
            //        Country="UK",
            //    }
            //};
            //var categoryIdList = new SelectList(categories, dataValueField: "Id",
            //    dataTextField: "Name");
            //var SuppliersList = new SelectList(suppliers, dataValueField: "Id",
            //   dataTextField: "Name");
            //var categoryIdList = _applicationDbContext.Category.ToList();
            var suppliers = _applicationDbContext.Supplier.ToList();
            var Categories = _applicationDbContext.Category.ToList();
            var categoryIdList = new SelectList(Categories, dataValueField: "Id",
              dataTextField: "Name");
            var SuppliersList = new SelectList(suppliers, dataValueField: "Id",
               dataTextField: "Name");
            ViewBag.Categories = categoryIdList;
            ViewBag.Suppliers = SuppliersList;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            _applicationDbContext.Add(product);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    var product = await _applicationDbContext.Product.FindAsync(id);
        //    PopulateDropdowns();
        //    return View(product);
        //}
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var product = await _applicationDbContext.Product.FindAsync(id);
        //    //var product = await _reader.GetProductByIdAsync(id);
        //    if (product == null) return NotFound();
        //    PopulateDropdowns();
        //    return View(product);
        //}
        public async Task<IActionResult> Edit(int id)
        {
            //var product = await _applicationDbContext.Product.FindAsync(id); 
            // ✅ await added
            var products = await _product.GetProductByIdAsync(id);
            if (products == null) return NotFound();
            PopulateDropdowns();
            return View(products);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if(id != product.Id) return NotFound();
            _applicationDbContext.Update(product);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            //var product = await _applicationDbContext.Product.FindAsync(id);
            var products = await _product.GetProductByIdAsync(id);
            return View(products);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var product = await _applicationDbContext.Product.FindAsync(id);
            var products = await _product.GetProductByIdAsync(id);
            if (products != null)
            {
                _applicationDbContext.Product.Remove(products);
                _applicationDbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
