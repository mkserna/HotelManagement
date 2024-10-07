using HotelManagement.Validations;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models.DTOs;
public class BookingDTO
{

    [Required(ErrorMessage = "Start date is required.")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "End date is required.")]
    [DataType(DataType.Date)]
    [CompareDate("StartDate", ErrorMessage = "End date must be after the start date.")]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "Total cost is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Total cost must be a positive number.")]
    public double TotalCost { get; set; }

    [Required(ErrorMessage = "Room ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Room ID must be a positive integer.")]
    public int RoomId { get; set; }

    [Required(ErrorMessage = "Guest ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Guest ID must be a positive integer.")]
    public int GuestId { get; set; }

    [Required(ErrorMessage = "Employee ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Employee ID must be a positive integer.")]
    public int EmployeeId { get; set; }
}