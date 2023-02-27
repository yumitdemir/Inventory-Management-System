using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models.Validations
{
    public class PriceValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string priceString = (string)value;
            decimal price;

            if (decimal.TryParse(priceString, out price))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The Price must be a number.");
            }
        }
    }
}
