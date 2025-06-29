using Horus.Domain.Contracts.Repositories;
using Horus.Infra.Database.Implementations;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Horus.Infra.Database;
public static class DependencyInjection
{
    public static IServiceCollection AddDatabaseInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HorusApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("Horus.Infra.Database"));

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                options.EnableSensitiveDataLogging();
        });

        services.AddScoped<IDroneTelemetryRepository, DroneTelemetryRepository>();

        return services;
    }
}
