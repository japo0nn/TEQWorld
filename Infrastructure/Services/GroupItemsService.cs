using Microsoft.Extensions.Logging;

namespace Infrastructure.Services;

public class GrouperService : IGrouperService
{
    private const double MaxTotalPrice = 200;

    private readonly IGroupRepository _groupRepository;
    private readonly IItemRepository _itemRepository;
    private readonly ILogger<GrouperService> _logger;

    public GrouperService(
        IGroupRepository groupRepository,
        IItemRepository itemRepository,
        ILogger<GrouperService> logger
    )
    {
        _groupRepository = groupRepository;
        _itemRepository = itemRepository;
        _logger = logger;
    }

    public async Task GroupItems()
    {
        var items = await _itemRepository.FindAsync(query =>
            query.Where(x => !x.IsUsed && x.Quantity > 0)
        );
        var groups = await _groupRepository.GetAllAsync();
        int groupsCount = groups.Count;
        while (items.Any())
        {
            var group = CreateGroup(items, groupsCount);

            if (group.Items.Any())
            {
                foreach (var groupItem in group.Items)
                {
                    var item = items.FirstOrDefault(x => x.Name.Equals(groupItem.Name));
                    if (item == null)
                    {
                        _logger.LogError("Ошибка при поиске товара из списка");
                        return;
                    }
                    item.Quantity -= groupItem.Quantity;
                }

                items = items.Where(x => x.Quantity > 0 && x.IsUsed).ToList();
                await _groupRepository.AddAsync(group);
            }
            else
            {
                break;
            }
        }

        items = await _itemRepository.FindAsync(query => query.Where(x => x.Quantity <= 0));
        foreach (var item in items)
        {
            _itemRepository.Remove(item);
        }
        return;
    }

    private ItemsGroup CreateGroup(List<Item> items, int order)
    {
        var group = ItemsGroup.Create($"Группа {order + 1}");
        double currentTotalPrice = 0;

        foreach (var item in items)
        {
            if (currentTotalPrice >= MaxTotalPrice)
                break;

            int maxQuantity = (int)((MaxTotalPrice - currentTotalPrice) / item.PricePerUnit);
            int quantity = Math.Min(item.Quantity, maxQuantity);

            if (quantity > 0)
            {
                group.AddItems(
                    Item.Create(item.Name, item.UnitOfMeasure, item.PricePerUnit, quantity, true)
                );

                currentTotalPrice += quantity * item.PricePerUnit;
            }
        }

        group.Update(currentTotalPrice);
        return group;
    }
}
