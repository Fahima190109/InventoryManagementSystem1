using InventoryManagementSystem1.Data;
using InventoryManagementSystem1.Models;
//using InventoryManagementSystem1.Models.Category;
//using InventoryManagementSystem1.Models.Product;
//using InventoryManagementSystem1.Models.Supplier;
using InventoryManagementSystem1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace InventoryManagementSystem1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            //Service->student Data fatch ->student model
            var products = ProductRepository.GetAll();
            return View(products);
            //return View();
        }
        public IActionResult Details(int id)
        {
            var products = ProductRepository.GetById(id);
            return View(products);
        }
        //[HttpPost] request nia kotha Ab
        public IActionResult Create()
        {
            //ProductRepository.Add(product);
            //return RedirectToAction("Index");
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
        //[HttpPost]
        //public async Task<IActionResult>Create(Product product)
        //{
        //    _applicationDbContext.Add(product);
        //    _applicationDbContext.SaveChanges();
        //    return RedirectToAction("Index");
        //}
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
