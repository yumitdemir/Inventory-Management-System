using Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //! public DbSet<RowClassName> ColumnClassName { get; set; }  // CloumnClassName = Dataset Column

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Categorie> Categories { get; set; }
    }
}
