namespace Horus.Infra.Database;

public class HorusApplicationDbContext(DbContextOptions<HorusApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Entity<string>> Entities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
