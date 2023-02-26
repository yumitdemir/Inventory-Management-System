using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set;}
        public string? ProductCode { get; set; }
        
        public int SupplierId { get; set; }
        //! Navigation property enetity frameworks need to acces to another table.
    
       
        public int CategoryId { get; set; }
        //! Navigation property enetity frameworks need to acces to another table.



    }
}
