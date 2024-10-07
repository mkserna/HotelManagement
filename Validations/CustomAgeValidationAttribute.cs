using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Validations;
public class CustomAgeValidationAttribute : ValidationAttribute
{
    private readonly int _minimumAge;

    public CustomAgeValidationAttribute(int minimumAge)
    {
        _minimumAge = minimumAge;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateOnly birthDate)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - birthDate.Year;

            if (birthDate.AddYears(age) > today)
                age--;

            if (age < _minimumAge)
            {
                return new ValidationResult(ErrorMessage);
            }
        }

        return ValidationResult.Success;
    }
}

