using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models.Validations
{
    public class SupplierIdValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           

            if ((int)value == 0)
            {
                return new ValidationResult("Please choose a valid supplier");
            }

            return ValidationResult.Success;
        }
    }
}
