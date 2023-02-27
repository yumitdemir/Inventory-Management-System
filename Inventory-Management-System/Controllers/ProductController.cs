using Inventory_Management_System.Data;
using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;

namespace Inventory_Management_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _context;
        public ProductController(IProductRepository context) {
            _context = context;
        }

        public async Task<IActionResult> Index(int id, int showNum)
        {
            if (showNum == 0)
            {
                showNum = 50;
            }
            IEnumerable<Product> products = await _context.GetAllDataAsync();
            IEnumerable<Supplier> suppliers = await _context.GetAllSupliers();   
            var categories = await _context.GetAllCategories();
            var maxPageIndex = Math.Ceiling((double)products.Count() / showNum);
            Console.WriteLine(maxPageIndex);
            //! If id doesn't exist in the link it will return 0
            if (id == 1 || id == 0)
            {
                products = products.Take(showNum);
            }
            else
            {

                products = products.Skip((id - 1) * showNum).Take(showNum);
            }

            IndexData data = new IndexData();
            data.products = products;
            data.maxPageIndex = maxPageIndex;
            data.id = id;
            data.showNum = showNum;
            data.suppliers = suppliers;
            data.categories = categories;
            return View(data);
        }


        [HttpPost]
         [Route("api/Product/NewView")]
        public IActionResult NewView([FromBody] string newView)
        {
           var a =  Url.Action("Index", "Product", new { id = 1, showNum = int.Parse(newView) });
            return Ok(a);
        }



        public class InputString
        {
            public string dataString { get; set; }
        }

        [HttpPost]
        [Route("api/CreateProduct/Suppliers")]
        public async Task<IActionResult> SuppliersList([FromBody] InputString data)
        {
            Console.WriteLine("test");
            IEnumerable<Supplier> allSuppliers = await _context.GetAllSupliers();

            if (!string.IsNullOrEmpty(data.dataString))
            {
                var results = allSuppliers.Where(item => item.Name.ToLower().Contains(data.dataString.ToLower())).ToList();
                return Ok(results);
            }
            
            return Ok(data);
        }



        public  IActionResult CreateProduct()
        {
            Product product = new Product();

            dynamic data = new ExpandoObject();
            data.product = product;

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            _context.Add(product); //!add is async function I created on repostiroy
            return RedirectToAction("Index", new { id = "1", showNum = 50 });
           

        }


    }



}

