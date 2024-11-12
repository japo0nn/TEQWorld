using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces.Context;

public interface IApplicationDbContext
{
    DbSet<Item> Items { get; }
    DbSet<ItemsGroup> ItemsGroups { get; }
}
