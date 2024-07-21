namespace TodoList.TodoGroups;

public static class ItemsEndpoints
{
    public static void Register(WebApplication app)
    {
        var group = app.MapGroup("group/{groupId:guid}/item");
        
        MapCreateItem(group);
    }
    

    private static void MapCreateItem(IEndpointRouteBuilder builder) =>
        builder.MapPost("/", async (CancellationToken ct) =>
        {
            return Results.Ok();
        });
}