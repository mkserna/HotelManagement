using HotelManagement.Models;

namespace HotelManagement.Repositories;
public interface IRoomTypeRepository
{
    Task<IEnumerable<RoomType>> GetAll();
    Task<RoomType> GetById(int id);
}
