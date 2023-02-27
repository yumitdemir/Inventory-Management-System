using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models.Validations
{
    public class QuantityValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            int quantity;

            if (int.TryParse(value.ToString(), out quantity) && quantity > 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The Quantity can't be 0");
            }
        }
    }
}
