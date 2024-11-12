namespace Infrastructure.Repositories;

public class GroupRepository : BaseRepository<ItemsGroup>, IGroupRepository
{
    public GroupRepository(ApplicationDbContext context)
        : base(context) { }

    public async Task<ItemsGroup> GetByIdAsync(Guid id)
    {
        return await _context
            .ItemsGroups.Include(x => x.Items)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
}
