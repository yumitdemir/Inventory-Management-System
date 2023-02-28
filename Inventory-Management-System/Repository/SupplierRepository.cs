using Inventory_Management_System.Data;
using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Supplier>> GetAllSupliers()
        {
            return await _context.Suppliers.ToListAsync();
        }


        public async Task<Supplier> GetDataByIDAsync(int id)
        {
            return await _context.Suppliers.FirstOrDefaultAsync(i => i.SupplierId.Equals(id));
        }
        public bool Add(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            return Save();
        }
        public bool Delete(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
            return Save();
        }
        public bool Update(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            return Save();
        }
        public bool Save()
        {
            var a = _context.SaveChanges();
            return a > 0 ? true : false;

        }

    }
}
