using Inventory_Management_System.Models.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter a Name.")]
        public string? Name { get; set; }
      
        [Required(ErrorMessage = "Please enter a Description.")]
        public string? Description { get; set; }
       
        [Required(ErrorMessage = "Please enter a Price.")]
        [PriceValidationAttribute]
        public string Price { get; set; }
        
        [Required(ErrorMessage = "Please enter a Quantity.")]
        [QuantityValidationAttribute]
        public int Quantity { get; set;}
        
        [Required(ErrorMessage = "Please enter a ProductCode.")]
        public string? ProductCode { get; set; }

        
        [Required(ErrorMessage = "Please enter a Supplier.")]
        [SupplierIdValidationAttribute]
        public int SupplierId { get; set; }


        [Required(ErrorMessage = "Please enter a Category.")]
        public int CategoryId { get; set; }
        //! Navigation property enetity frameworks need to acces to another table.



    }
}
