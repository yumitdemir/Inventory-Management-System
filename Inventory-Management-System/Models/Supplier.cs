using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [Required(ErrorMessage = "Please enter a Name.")]
        public string? Name { get; set; }
       
        [Required(ErrorMessage = "Please enter a Address.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Please enter a Phone Number.")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Please enter a Email.")]
        public string? Email { get; set; }


    }
}
