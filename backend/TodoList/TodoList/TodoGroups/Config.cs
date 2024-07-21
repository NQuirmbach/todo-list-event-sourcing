using Marten;
using Marten.Events.Projections;
using TodoList.TodoGroups.Projections;

namespace TodoList.TodoGroups;

public static class Config
{
    public static void MapTodoGroupsEndpoints(this WebApplication app)
    {
        GroupEndpoints.Register(app);
        ItemsEndpoints.Register(app);
    }

    public static StoreOptions RegisterTodoGroupProjections(this StoreOptions options)
    {
        options.Projections.Add<TodoGroupProjection>(ProjectionLifecycle.Inline);

        return options;
    }
}