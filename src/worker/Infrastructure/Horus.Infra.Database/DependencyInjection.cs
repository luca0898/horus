using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Horus.Infra.Database;
public static class DependencyInjection
{
    public static IServiceCollection AddDatabaseInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HorusApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                options.EnableSensitiveDataLogging(); // Enable sensitive data logging for debugging purposes, remove in production
        });


        return services;
    }
}
