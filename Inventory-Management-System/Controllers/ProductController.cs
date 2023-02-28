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
     
        public async Task<IActionResult> Index(int id, int showNum,string searchInput)
        {
           
            if (showNum == 0)
            {
                showNum = 50;
            }
            IEnumerable<Product> products = await _context.GetAllDataAsync();
            IEnumerable<Supplier> suppliers = await _context.GetAllSupliers();

            if (!string.IsNullOrEmpty(searchInput))
            {
                products = products.Where(p => p.Name.ToLower().Contains(searchInput.ToLower()));
            }

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

            IndexDataProduct data = new IndexDataProduct();
            data.products = products;
            data.maxPageIndex = maxPageIndex;
            data.id = id;
            data.showNum = showNum;
            data.suppliers = suppliers;
            data.categories = categories;
            data.searchInput = searchInput;
            return View(data);
        }

        public class newview
        {
            public string newView { get; set; }
            public string currentSearch { get; set; }

        }

        [HttpPost]
         [Route("api/Product/NewView")]
        public IActionResult NewView([FromBody] newview newView)
        {
           var a =  Url.Action("Index", "Product", new { id = 1, showNum = int.Parse(newView.newView), searchInput= newView.currentSearch });
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


        
        public async Task<IActionResult> EditProduct(int id)
        {
            Product product = await _context.GetDataByIDAsync(id);
            var suppliers = await _context.GetAllSupliers();
            var supplier = suppliers.FirstOrDefault(i => i.SupplierId == product.SupplierId);
            if (supplier == null)
            {
                supplier = new Supplier();
                supplier.SupplierId = 0;
                supplier.Name = "";
                supplier.Email = "";
                supplier.Phone= "";
                supplier.Address = "";
            }


            EditViewModel data = new EditViewModel();
            data.product= product;
            data.supplier = supplier;
            return View(data);

        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit the product");
                return Redirect("EditProduct");
            }

            Product newProduct = new Product();
            Console.WriteLine(product.ProductId + "dsadsads");
            newProduct.ProductId = product.ProductId;
            newProduct.Name = product.Name;
            newProduct.Description = product.Description;
            newProduct.Price = product.Price;
            newProduct.Quantity = product.Quantity;
            newProduct.ProductCode = product.ProductCode; 
            newProduct.SupplierId = product.SupplierId;
            newProduct.CategoryId = product.CategoryId;

           
            _context.Update(newProduct);

            return RedirectToAction("Index");

        }

        
        public async Task<IActionResult> DeleteProduct(int productId , int id ,string searchInput, int showNum)
        {
            
            Product product = await _context.GetDataByIDAsync(productId);
            _context.Delete(product);

            return RedirectToAction("Index", new { id = id, searchInput = searchInput, showNum = showNum });
        }

    }


    }





