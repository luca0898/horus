using Horus.Domain.Enums;

namespace Horus.Domain.Entities;

public sealed class DroneTelemetry(string droneId, DateTime timestamp) : DroneTelemetryCompositeKey(droneId, timestamp)
{
    public DroneTelemetryCompositeKey Key { get => new(DroneId, Timestamp); }

    private int _battery;
    public int Battery
    {
        get => _battery;
        set
        {
            _battery = value >= 0 && value <= 100
                ? value
                : throw new ArgumentOutOfRangeException(nameof(Battery), "Battery percentage must be between 0 and 100.");
        }
    }

    public DroneTelemetryEnum Status { get; set; } = DroneTelemetryEnum.STANDBY;

    private double _latitude;
    public double Latitude { get => _latitude; set { _latitude = Math.Round(value, 6); } }

    private double _longitude;
    public double Longitude { get => _longitude; set { _longitude = Math.Round(value, 6); } }

    private double _altitude;
    public double Altitude { get => _altitude; set { _altitude = Math.Round(value, 2); } }
}
