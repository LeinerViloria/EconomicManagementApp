using System.ComponentModel.DataAnnotations;

namespace EconomicManagementAPP.Validations
{
    public class MinZero:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            value = (value == null || string.IsNullOrEmpty(value.ToString())) ? "0" : value.ToString().Replace(".", ",");

            if (!Decimal.TryParse(value.ToString(), out Decimal numBalance))
            {
                return new ValidationResult("The balance must be a decimal");
            }
            
            if (numBalance < 0)
            {
                return new ValidationResult("The balance must be equals or greater than zero");
            }

            return ValidationResult.Success;
        }
    }
}
