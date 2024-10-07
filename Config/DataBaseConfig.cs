using HotelManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Config;
public static class DataBaseConfig
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services)
    {

        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbDatabaseName = Environment.GetEnvironmentVariable("DB_DATABASE");
        var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
        var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

        if (string.IsNullOrEmpty(dbHost) ||
            string.IsNullOrEmpty(dbPort) ||
            string.IsNullOrEmpty(dbDatabaseName) ||
            string.IsNullOrEmpty(dbUser) ||
            string.IsNullOrEmpty(dbPassword))
        {
            throw new InvalidOperationException("Missing environment variables for database configuration.");
        }

        var connectionDB = $"server={dbHost};port={dbPort};database={dbDatabaseName};uid={dbUser};password={dbPassword}";

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionDB, ServerVersion.Parse("8.0.20-mysql")));

        return services;
    }
}
