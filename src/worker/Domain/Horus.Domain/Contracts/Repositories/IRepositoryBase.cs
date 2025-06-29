namespace Horus.Domain.Contracts.Repositories;
public interface IRepositoryBase<TKey, TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
}