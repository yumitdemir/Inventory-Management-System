using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }


    }
}
