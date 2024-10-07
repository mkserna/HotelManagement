using HotelManagement.Validations;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models.DTOs;
public class RoomDTO
{
    [Required(ErrorMessage = "Room number is required.")]
    [StringLength(10, ErrorMessage = "Room number can't be longer than 10 characters.")]
    public string RoomNumber { get; set; }

    [Required(ErrorMessage = "Room type is required.")]
    [CustomRoomTypeValidation(ErrorMessage = "Invalid occupancy for the selected room type.")]
    public int RoomTypeId { get; set; }

    [Required(ErrorMessage = "Availability is required.")]
    public bool Availability { get; set; }

    [Required(ErrorMessage = "Max occupancy is required.")]
    [Range(1, 10, ErrorMessage = "Max occupancy must be between 1 and 10 persons.")]
    public byte MaxOccupancyPerson { get; set; }

    public double PricePerNight { get; set; }
}
