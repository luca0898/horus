using Horus.Domain.Contracts.Repositories;

namespace Horus.Infra.Database.Implementations;
public class DroneTelemetryRepository(HorusApplicationDbContext context) : IDroneTelemetryRepository
{
    public async Task AddAsync(DroneTelemetry entity)
    {
        await context.DroneTelemetries.AddAsync(entity);
    }
}
