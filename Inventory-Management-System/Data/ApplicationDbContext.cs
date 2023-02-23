using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //! public DbSet<RowClassName> ColumnClassName { get; set; }  // CloumnClassName = Dataset Column
    }
}
