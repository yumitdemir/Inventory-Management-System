using Inventory_Management_System.Data;
using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

            dynamic data = new ExpandoObject();
            data.products = products;
            data.maxPageIndex = maxPageIndex;
            data.id = id;
            data.showNum = showNum;
            return View(data);
        }


        [HttpPost]
        [Route("/api/Product/NewView")]
        public IActionResult NewView([FromBody] string newView)
        {
           var a =  Url.Action("Index", "Product", new { id = 1, showNum = int.Parse(newView) });
            return Ok(a);
        }
    }



}

