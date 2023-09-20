namespace TodoTaskManagement.Domain.Interfaces;

public interface ITodoItemRepository
{
    Task<TodoItem?> GetById(TodoItemId id);
    Task<IEnumerable<TodoItem>> GetAll();
    Task Add(TodoItem todoItem);
}