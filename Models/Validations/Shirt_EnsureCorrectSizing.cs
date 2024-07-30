using System.ComponentModel.DataAnnotations;

namespace Fliu.Models.Validations
{
    public class Shirt_EnsureCorrectSizingAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Shirt? shirt = validationContext.ObjectInstance as Shirt;
            Console.WriteLine(shirt); 
            
            if (shirt != null && string.IsNullOrEmpty(shirt.Gender) == false)
            {
                if (shirt.Gender.Equals("men", StringComparison.OrdinalIgnoreCase) && shirt.Size < 8)
                {
                    return new ValidationResult("Men's sizes must be >= 8");
                }
                if (shirt.Gender.Equals("women", StringComparison.OrdinalIgnoreCase) && shirt.Size < 6)
                {
                    return new ValidationResult("Women's sizes must be >= 6");
                }
            }
            return ValidationResult.Success;
        }
    }
}
