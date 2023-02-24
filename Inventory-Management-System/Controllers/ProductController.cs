using Inventory_Management_System.Data;
using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace Inventory_Management_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _context;
        public ProductController(IProductRepository context) {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            IEnumerable<Product> products = await _context.GetAllDataAsync();
           var maxPageIndex = Math.Ceiling((double)products .Count()/ 50);
            Console.WriteLine(maxPageIndex);
            //! If id doesn't exist in the link it will return 0
            if (id == 1 || id == 0)
            {
                products = products.Take(50);
            }
            else
            {
                
                products = products.Skip((id - 1) * 50).Take(50);
            }

            dynamic data = new ExpandoObject();
            data.products = products;
            data.maxPageIndex = maxPageIndex;
            data.id = id;
            return View(data);
        }
      


    }
}
