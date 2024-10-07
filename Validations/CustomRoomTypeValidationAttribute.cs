using HotelManagement.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Validations;
public class CustomRoomTypeValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var roomDto = (RoomDTO)validationContext.ObjectInstance;

        switch (roomDto.RoomTypeId)
        {
            case 1:
                if (roomDto.MaxOccupancyPerson != 1)
                    return new ValidationResult("For a Simple Room, the maximum occupancy must be 1 person.");
                roomDto.PricePerNight = 50; 
                break;
            case 2:
                if (roomDto.MaxOccupancyPerson != 2)
                    return new ValidationResult("For a Double Room, the maximum occupancy must be 2 persons.");
                roomDto.PricePerNight = 80; 
                break;
            case 3:
                if (roomDto.MaxOccupancyPerson != 2)
                    return new ValidationResult("For a Suite, the maximum occupancy must be 2 persons.");
                roomDto.PricePerNight = 150;
                break;
            case 4:
                if (roomDto.MaxOccupancyPerson != 4)
                    return new ValidationResult("For a Family Room, the maximum occupancy must be 4 persons.");
                roomDto.PricePerNight = 200; 
                break;
            default:
                return new ValidationResult("Invalid RoomTypeId.");
        }

        return ValidationResult.Success;
    }
}


