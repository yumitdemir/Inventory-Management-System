using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Inventory_Management_System.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository _context;
        public SupplierController(ISupplierRepository context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int id, int showNum, string searchInput)
        {
            if (showNum == 0)
            {
                showNum = 50;
            }
            
            IEnumerable<Supplier> suppliers = await _context.GetAllSupliers();

            if (!string.IsNullOrEmpty(searchInput))
            {
                suppliers = suppliers.Where(p => p.Name.ToLower().Contains(searchInput.ToLower()));
            }

          
            var maxPageIndex = Math.Ceiling((double)suppliers.Count() / showNum);
            Console.WriteLine(maxPageIndex);
            //! If id doesn't exist in the link it will return 0
            if (id == 1 || id == 0)
            {
                suppliers = suppliers.Take(showNum);
            }
            else
            {

                suppliers = suppliers.Skip((id - 1) * showNum).Take(showNum);
            }

            IndexDataSupplier data = new IndexDataSupplier();
            data.maxPageIndex = maxPageIndex;
            data.id = id;
            data.showNum = showNum;
            data.suppliers = suppliers;
            data.searchInput = searchInput;


            return View(data);
           
        }


        public class newViews
        {
            public string newView { get; set; }
            public string currentSearch { get; set; }

        }

        [HttpPost]
        [Route("/api/Supplier/NewView")]
        public IActionResult NewView([FromBody] newViews newView)
        {
            Console.WriteLine("test");

            var a = Url.Action("Index", "Supplier", new { id = 1, showNum = int.Parse(newView.newView), searchInput = newView.currentSearch });
            return Ok(a);
        }


        public IActionResult CreateSupplier()
        {
            Supplier supplier = new Supplier();
            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Add(supplier); 
            return RedirectToAction("Index", new { id = "1", showNum = 50 });


        }


        public async Task<IActionResult> EditSupplier(int id)
        {
            Supplier supplier = await _context.GetDataByIDAsync(id);
            return View(supplier);

        }

        [HttpPost]
        public async Task<IActionResult> EditSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit the supplier");
                return Redirect("EditSupplier");
            }

            Supplier newSupplier = new Supplier();

            newSupplier.SupplierId = supplier.SupplierId;
            newSupplier.Name = supplier.Name;
            newSupplier.Email = supplier.Email;
            newSupplier.Address = supplier.Address;
            newSupplier.Phone = supplier.Phone;

            _context.Update(newSupplier);

            return RedirectToAction("Index", new { id = 1,  showNum = 50 });

        }
        public async Task<IActionResult> DeleteSupplier(int supplierId, int id, string searchInput, int showNum)
        {

            Supplier supplier = await _context.GetDataByIDAsync(supplierId);
            _context.Delete(supplier);

            return RedirectToAction("Index", new { id = id, searchInput = searchInput, showNum = showNum });
        }


    }
}
