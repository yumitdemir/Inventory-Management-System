using Inventory_Management_System.Data;
using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
         
        }

        public async Task<IEnumerable<Supplier>> GetAllSupliers()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<IEnumerable<Categorie>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllDataAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetDataByIDAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(i => i.ProductId.Equals(id));

        }
        public bool Add(Product product)
        {
            _context.Products.Add(product);
            return Save();
        }
        public bool Delete(Product product)
        {
            _context.Products.Remove(product);
            return Save();
        }
        public bool Update(Product product)
        {
            _context.Products.Update(product);
            return Save();
        }
        public bool Save()
        {
            var a = _context.SaveChanges();
            return a > 0 ? true: false;

        }
      
    }
}
