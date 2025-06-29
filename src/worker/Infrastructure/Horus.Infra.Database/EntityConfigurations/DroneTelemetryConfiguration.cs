namespace Horus.Infra.Database.EntityConfigurations;
public class DroneTelemetryConfiguration : IEntityTypeConfiguration<DroneTelemetry>
{
    public void Configure(EntityTypeBuilder<DroneTelemetry> builder)
    {
        builder.ToTable("drone_telemetries", "public");

        builder.HasKey(d => new { d.DroneId, d.Timestamp });

        builder.Property(d => d.DroneId)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Timestamp)
            .IsRequired();

        builder.Property(d => d.Battery)
            .IsRequired();

        builder.Property(d => d.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(d => d.Latitude)
            .IsRequired()
            .HasPrecision(9, 6);

        builder.Property(d => d.Longitude)
            .IsRequired()
            .HasPrecision(9, 6);

        builder.Property(d => d.Altitude)
            .IsRequired()
            .HasPrecision(10, 2);
    }
}
