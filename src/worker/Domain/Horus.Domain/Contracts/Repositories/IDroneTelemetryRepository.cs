using Horus.Domain.Entities;

namespace Horus.Domain.Contracts.Repositories;
public interface IDroneTelemetryRepository : IRepositoryBase<DroneTelemetryCompositeKey, DroneTelemetry>;