using HotelManagement.Models;
using HotelManagement.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Seeders;
public class EmployeeSeeder
{
    private readonly IPasswordHasher _passwordHasher;

    public EmployeeSeeder(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            CreateEmployee(1, "Maria", "Sanchez", "maria@gmail.com", "123456789", "MariaSanchez123!"),
            CreateEmployee(2, "Juan", "Gonzalez", "juan@gmail.com", "987654321", "JuanGonzalez123!"),
            CreateEmployee(3, "Ana", "Martinez", "ana@gmail.com", "456789123", "AnaMartinez123!"),
            CreateEmployee(4, "Luis", "Perez", "luis@gmail.com", "321654987", "LuisPerez123!"),
            CreateEmployee(5, "Laura", "Hernandez", "laura@gmail.com", "159753468", "LauraHernandez123!"),
            CreateEmployee(6, "Carlos", "Lopez", "carlos@gmail.com", "753159864", "CarlosLopez123!")
        );
    }

    private Employee CreateEmployee(int id, string firstName, string lastName, string email, string identificationNumber, string password)
    {
        return new Employee
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            IdentificationNumber = identificationNumber,
            Password = _passwordHasher.HashPassword(password)
        };
    }
}
