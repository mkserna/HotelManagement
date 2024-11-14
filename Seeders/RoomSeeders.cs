using HotelManagement.Models;

namespace HotelManagement.Seeders;
public class RoomSeeder
{
    public static List<Room> GetRooms()
    {
        var rooms = new List<Room>();
        for (int i = 0; i < 50; i++)
        {
            int roomTypeId = (i % 4) + 1; // Esto asigna RoomTypeId entre 1 y 4
            bool availability = i % 2 == 0; // Alterna disponibilidad entre true y false
            
            rooms.Add(new Room
            {
                RoomNumber = (101 + i).ToString(), // Genera números de habitación desde 101
                RoomTypeId = roomTypeId,
                Availability = availability
            });
        }
        return rooms;
    }
}


