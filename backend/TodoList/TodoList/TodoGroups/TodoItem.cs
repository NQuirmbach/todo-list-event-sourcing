namespace TodoList.TodoGroups;

public class TodoItem : Entity
{
    public string Name { get; init; }
    public bool IsDone { get; set; }
}