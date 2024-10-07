using HotelManagement.Data;
using HotelManagement.Models;
using HotelManagement.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services
{
    public class RoomServices : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Room>> GetAll()
        {
            return await _context.Rooms.ToListAsync(); // Devuelve todas las habitaciones
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await GetAll(); // Llama al método anterior
        }

        public async Task<Room> GetAvailable()
        {
            // Obtiene la primera habitación disponible
            return await _context.Rooms
                .FirstOrDefaultAsync(r => !r.Availability); // Asumiendo que hay una propiedad IsOccupied
        }

        public async Task<Room> GetById(int id)
        {
            return await _context.Rooms.FindAsync(id); // Busca una habitación por ID
        }

        public async Task<IEnumerable<Room>> GetOccupiedRooms()
        {
            return await _context.Rooms
                .Where(r => r.Availability)
                .ToListAsync(); // Devuelve todas las habitaciones ocupadas
        }

    }
}
