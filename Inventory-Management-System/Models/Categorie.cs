using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models
{
    public class Categorie
    {
        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
