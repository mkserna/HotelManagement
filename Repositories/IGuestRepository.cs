
using HotelManagement.Models;

namespace HotelManagement.Repositories;
public interface IGuestRepository
{
    Task Add(Guest guest);
    Task<Guest> GetById(int id);
    Task<IEnumerable<Guest>> GetAll();
    Task Update(Guest guest);
    Task Delete(int id);
    Task<IEnumerable<Guest>> GetByKeyword(string keyword);
    Task<bool> CheckExistence(int id);

}
