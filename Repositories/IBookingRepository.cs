using HotelManagement.Models;

namespace HotelManagement.Repositories;
public interface IBookingRepository
{
    Task<IEnumerable<Booking>> GetAll();
    Task<Booking> GetById(int id);
    Task Add(Booking booking);
    Task Update(Booking booking);
    Task Delete(int id);
    Task<bool> CheckExistence(int id);
    Task<Booking> GetByIdentificationNumber(string identificationNumber);

}
