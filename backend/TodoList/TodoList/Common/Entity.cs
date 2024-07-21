namespace TodoList.Common;

public abstract class Entity
{
    public Guid Id { get; init; }
    
    public DateTimeOffset CreatedAt { get; init; }
}