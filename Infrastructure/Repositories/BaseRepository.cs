namespace Infrastructure.Repositories;

public class BaseRepository<TEntity>(ApplicationDbContext context) : IBaseRepository<TEntity>
    where TEntity : class
{
    protected readonly ApplicationDbContext _context = context;

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        _context.SaveChanges();
    }

    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        _context.SaveChanges();
    }

    public async Task<List<TEntity>> FindAsync(
        Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate
    )
    {
        var query = _context.Set<TEntity>().AsQueryable();
        query = predicate(query);
        return await query.ToListAsync();
    }
}
