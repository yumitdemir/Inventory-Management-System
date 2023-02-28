namespace Inventory_Management_System.Models
{
    public class IndexDataSupplier
    {
        public double maxPageIndex { get; set; }
        public int id { get; set; }
        public int showNum { get; set; }
        public IEnumerable<Supplier> suppliers { get; set; }

        public string searchInput { get; set; }


    }
}
