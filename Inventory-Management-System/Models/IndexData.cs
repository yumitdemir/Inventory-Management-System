namespace Inventory_Management_System.Models
{
    public class IndexData
    {
        public IEnumerable<Product> products { get; set; }
        public double maxPageIndex { get; set; }
        public int id { get; set; }
        public int showNum { get; set; }
        public IEnumerable<Supplier> suppliers { get; set; }

        public IEnumerable<Categorie> categories { get; set; }
      
    }
}
