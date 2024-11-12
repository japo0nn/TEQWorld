namespace Domain.Entities;

public class Item : BaseEntity
{
    public string Name { get; set; }
    public string UnitOfMeasure { get; set; }
    public double PricePerUnit { get; set; }
    public int Quantity { get; set; }
    public bool IsUsed { get; set; }

    private Item(
        string name,
        string unitOfMeasure,
        double pricePerUnit,
        int quantity,
        bool isUsed = false
    )
    {
        Name = name;
        UnitOfMeasure = unitOfMeasure;
        PricePerUnit = pricePerUnit;
        Quantity = quantity;
        IsUsed = isUsed;
    }

    public static Item Create(string name, string unitOfMeasure, double pricePerUnit, int quantity)
    {
        return new Item(name, unitOfMeasure, pricePerUnit, quantity);
    }

    public static Item Create(
        string name,
        string unitOfMeasure,
        double pricePerUnit,
        int quantity,
        bool isUsed
    )
    {
        return new Item(name, unitOfMeasure, pricePerUnit, quantity, isUsed);
    }

    public void Update(string unitOfMeasure, double pricePerUnit, int quantity)
    {
        UnitOfMeasure = unitOfMeasure;
        PricePerUnit = pricePerUnit;
        Quantity = quantity;
        this.Update();
    }

    public void Use()
    {
        IsUsed = true;
    }
}
