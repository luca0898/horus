using System.Reflection;

namespace Horus.Infra.Database;

public class HorusApplicationDbContext(DbContextOptions<HorusApplicationDbContext> options) : DbContext(options)
{
    public DbSet<DroneTelemetry> DroneTelemetries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var applyConfigMethod = typeof(ModelBuilder).GetMethod("ApplyConfiguration");

        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
            .SelectMany(t => t.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                .Select(i => new { EntityType = i.GetGenericArguments()[0], ConfigType = t }))
            .ToList()
            .ForEach(cfg =>
            {
                var instance = Activator.CreateInstance(cfg.ConfigType);
                var method = applyConfigMethod!.MakeGenericMethod(cfg.EntityType);
                method.Invoke(modelBuilder, [instance]);
            });

    }
}
