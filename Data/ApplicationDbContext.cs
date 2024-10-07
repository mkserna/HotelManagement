using HotelManagement.Models;
using HotelManagement.Repositories;
using HotelManagement.Seeders;
using HotelManagement.Services;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RoomTypeSeeders.Seed(modelBuilder);

            // Instanciar el hasher directamente
            IPasswordHasher passwordHasher = new Sha256PasswordHasher();
            new EmployeeSeeder(passwordHasher).Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

    }
}