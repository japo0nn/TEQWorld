namespace Application.Common.Interfaces.Repositories;

public interface IBaseRepository<TEntity>
    where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(Guid id);
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<List<TEntity>> FindAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate);
}
