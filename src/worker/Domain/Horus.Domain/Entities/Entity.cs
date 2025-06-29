namespace Horus.Domain.Entities;

public class Entity<TKey>(TKey id)
{
    public TKey Id { get; set; } = id;
}
