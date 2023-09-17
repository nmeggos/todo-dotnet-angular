namespace TodoTaskManagement.Domain.Contracts;

public interface ITodoItemRepository
{
    Task<TodoItem?> Get(TodoItemId id);
    Task<IEnumerable<TodoItem>> GetAll();
}