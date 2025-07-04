using DienMayLongBien.Database.Inrceptors;
using Microsoft.EntityFrameworkCore;

namespace DienMayLongBien.Configurations;

public static class PostgresConfiguration
{
    public static IServiceCollection AddPostgres(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString =
            configuration["CONNECTION_STRING"]
            ?? throw new InvalidOperationException("DefaultConnection are missing");

        services.AddDbContext<AppDbContext>(
            (options) =>
            {
                options.UseNpgsql(connectionString);
            }
        );

        return services;
    }
}
