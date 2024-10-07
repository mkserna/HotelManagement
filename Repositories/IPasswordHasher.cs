
namespace HotelManagement.Repositories
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}