using Inventory_Management_System.Data;
using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management_System.Controllers
{
    public class SupplierDetailController : Controller
    {

        private readonly ApplicationDbContext _context;
        public SupplierDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            if (id == 0) {
                id = 1;
            }
           
            if (id <= _context.Suppliers.Count())
            {
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                Supplier supplier = _context.Suppliers.FirstOrDefault(s => s.SupplierId == id);
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                return View(supplier);
            }

            return View();

        }
    }
}
