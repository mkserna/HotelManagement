using HotelManagement.Data;
using HotelManagement.Models;
using HotelManagement.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services;
public class BookingServices : IBookingRepository
{
    private readonly ApplicationDbContext _context;

    public BookingServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Booking booking)
    {
        if (booking == null)
        {
            throw new ArgumentNullException(nameof(booking), "Booking cannot be null and void");
        }

        try
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error adding booking.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("An unexpected error occurred while adding the reservation.", ex);
        }
    }
    public async Task Delete(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking != null)
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<IEnumerable<Booking>> GetAll()
    {
        return await _context.Bookings.ToListAsync();
    }

    public async Task<bool> CheckExistence(int id)
    {
        try
        {
            return await _context.Bookings.AnyAsync(p => p.Id == id);
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error adding the booking to the database.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("An unexpected error occurred when adding the reservation.", ex);
        }
    }

    public async Task<Booking> GetById(int id)
    {
        return await _context.Bookings.FindAsync(id);
    }

    public async Task<Guest> GetByIdentificationNumber(int identificationNumber)
    {
        return await _context.Guests.FindAsync(identificationNumber);
    }


    public async Task Update(Booking booking)
    {
        if (booking == null)
        {
            throw new ArgumentNullException(nameof(booking), "The reservation cannot be null and void.");
        }

        try
        {
            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error updating the reservation in the database.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("An unexpected error occurred while updating the reservation.", ex);
        }
    }

    public Task<Booking> GetByIdentificationNumber(string identificationNumber)
    {
        throw new NotImplementedException();
    }
}
