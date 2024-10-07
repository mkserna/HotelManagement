using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Validations
{
    public class CompareDateAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;

    public CompareDateAttribute(string comparisonProperty)
    {
        _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var currentValue = (DateTime)value;
        var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
        var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);

        if (currentValue <= comparisonValue)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}

}