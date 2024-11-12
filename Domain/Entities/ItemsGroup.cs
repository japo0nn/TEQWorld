namespace Domain.Entities;

public class ItemsGroup : BaseEntity
{
    public string Name { get; set; }
    public double TotalPrice { get; set; }

    public ICollection<Item> Items { get; set; } = new List<Item>();

    private ItemsGroup(string name)
    {
        Name = name;
    }

    public static ItemsGroup Create(string name)
    {
        return new ItemsGroup(name);
    }

    public void Update(double totalPrice)
    {
        TotalPrice = totalPrice;
        this.Update();
    }

    public void AddItems(Item item)
    {
        Items.Add(item);
        this.Update();
    }
}
