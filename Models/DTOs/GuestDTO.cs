using HotelManagement.Validations;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models.DTOs;
public class GuestDTO
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

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    [StringLength(15, ErrorMessage = "Phone number can't be longer than 15 characters.")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Birth date is required.")]
    [DataType(DataType.Date)]
    [CustomAgeValidation(18, ErrorMessage = "You must be at least 18 years old.")]
    public DateOnly BirthDate { get; set; }
}
