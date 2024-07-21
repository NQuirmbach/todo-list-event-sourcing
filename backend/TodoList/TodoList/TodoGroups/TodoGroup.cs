namespace TodoList.TodoGroups;

public class TodoGroup : Entity
{
    public string Name { get; init; }
    public ICollection<TodoItem> Items { get; set; } = [];
}