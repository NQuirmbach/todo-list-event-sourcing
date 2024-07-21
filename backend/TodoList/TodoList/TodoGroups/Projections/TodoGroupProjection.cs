using Marten.Events;
using Marten.Events.Aggregation;
using TodoList.TodoGroups.Events;

namespace TodoList.TodoGroups.Projections;

public class TodoGroupProjection : SingleStreamProjection<TodoGroup>
{
    public TodoGroup Create(IEvent<TodoGroupCreated> created) => new()
    {
        Id = created.StreamId,
        Name = created.Data.Name,
        CreatedAt = created.Timestamp
    };
}