namespace Domain.Common;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset CreateTime { get; set; }
    public DateTimeOffset UpdateTime { get; set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreateTime = DateTimeOffset.UtcNow;
        UpdateTime = DateTimeOffset.UtcNow;
    }
}

public static class BaseEntityExtension
{
    public static BaseEntity Update(this BaseEntity entity)
    {
        entity.UpdateTime = DateTimeOffset.UtcNow;
        return entity;
    }
}
