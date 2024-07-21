using Marten;
using Marten.Events;
using TodoList.TodoGroups.Events;

namespace TodoList.TodoGroups;

public static class GroupEndpoints
{
    public static void Register(WebApplication app)
    {
        var group = app.MapGroup("group");

        MapCreateGroup(group);
    }
    
    private static void MapCreateGroup(IEndpointRouteBuilder builder) =>
        builder.MapPost("/", async (
            CreateTodoGroupRequest request,
            IDocumentStore store,
            CancellationToken ct
        ) =>
        {
            await using var session = store.LightweightSession();

            var created = new TodoGroupCreated(request.Name);
            var stream = session.Events.StartStream<TodoGroup>(created);

            await session.SaveChangesAsync(ct);

            var result = await session.LoadAsync<TodoGroup>(stream.Id, ct);
            
            return Results.Ok(result);
        });
}

public record CreateTodoGroupRequest(string Name);