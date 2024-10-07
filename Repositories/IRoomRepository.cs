using HotelManagement.Models;

namespace HotelManagement.Repositories;
public interface IRoomRepository
{
    Task<IEnumerable<Room>> GetAll();
    Task<Room> GetAvailable();
    Task<Room> GetById(int id);
    Task<IEnumerable<Room>> GetAllRoomsAsync();

}
