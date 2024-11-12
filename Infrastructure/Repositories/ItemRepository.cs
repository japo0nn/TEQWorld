namespace Infrastructure.Repositories;

public class ItemRepository : BaseRepository<Item>, IItemRepository
{
    public ItemRepository(ApplicationDbContext context)
        : base(context) { }
}
