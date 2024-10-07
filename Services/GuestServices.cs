using HotelManagement.Data;
using HotelManagement.Models;
using HotelManagement.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services;
public class GuestServices : IGuestRepository
{
    private readonly ApplicationDbContext _context;

    public GuestServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Guest guest)
    {
        if (guest == null)
        {
            throw new ArgumentNullException(nameof(guest), "Guest cannot be null and void");
        }

        try
        {
            await _context.Guests.AddAsync(guest);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error adding the guest to the database.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("An unexpected error occurred while adding the guest.", ex);
        }
    }

    public async Task<bool> CheckExistence(int id)
    {
        try
        {
            return await _context.Guests.AnyAsync(p => p.Id == id);
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error adding the guest to the database.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("An unexpected error occurred when adding the guest.", ex);
        }

    }

    public async Task Delete(int id)
    {
        var guest = await _context.Guests.FindAsync(id);
        if (guest != null)
        {
            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Guest>> GetAll()
    {
        return await _context.Guests.ToListAsync();
    }

    public async Task<Guest> GetById(int id)
    {
        return await _context.Guests.FindAsync(id);
    }

    public async Task<IEnumerable<Guest>> GetByKeyword(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return await GetAll();
        }

        return await _context.Guests.Where(
            p => p.FirstName.Contains(keyword) ||
            p.LastName.Contains(keyword)).ToListAsync();
    }

    public async Task Update(Guest guest)
    {
        if (guest == null)
        {
            throw new ArgumentNullException(nameof(guest), "Guest cannot be null and void");
        }

        try
        {
            _context.Entry(guest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error updating the guest in the database.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("An unexpected error occurred while updating the guest.", ex);
        }
    }
}
