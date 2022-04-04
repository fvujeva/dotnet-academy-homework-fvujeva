using System.ComponentModel.DataAnnotations;
using Library.FilipVujeva.Contracts.Dtos;

namespace Library.FilipVujeva.Contracts.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class UsaAddressAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is AddressDTO adress)
            {
                if (adress.Country.Equals("USA", StringComparison.OrdinalIgnoreCase) ||
                    adress.Country.Equals("United States of America", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (IsValid(value))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Sorry, we are currently available only for users with USA adress!");
            }
        }
    }
}
