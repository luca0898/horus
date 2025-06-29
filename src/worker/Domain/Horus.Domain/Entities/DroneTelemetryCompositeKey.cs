namespace Horus.Domain.Entities;
public class DroneTelemetryCompositeKey(string droneId, DateTime timestamp)
{
    public string DroneId { get; set; } = droneId;
    public DateTime Timestamp { get; set; } = timestamp;
}
