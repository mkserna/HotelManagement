
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models.DTOs;
public class EmployeeDTO
{
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name can't be longer than 50 characters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name can't be longer than 50 characters.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Identification number is required.")]
    [StringLength(20, ErrorMessage = "Identification number can't be longer than 20 characters.")]
    public string IdentificationNumber { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Password must have at least one uppercase letter, one lowercase letter, and one number.")]
    public string Password { get; set; }
}
