using TodoTaskManagement.Domain.Identifiers;

namespace TodoTaskManagement.Domain.Interfaces;

public interface ITodoCategoryRepository
{
    Task<IEnumerable<TodoCategory>> GetAllAsync();
    Task<TodoCategory> GetByIdAsync(TodoCategoryId id);
    Task<TodoCategoryId?> AddAsync(TodoCategory category);
    Task UpdateAsync(TodoCategory category);
}