
using TodoTaskManagement.Domain.Identifiers;

namespace TodoTaskManagement.Infrastructure.Persistence.Repositories;

public class TodoItemRepository : ITodoItemRepository
{
    private readonly TodoDbContext _dbContext;

    public TodoItemRepository(TodoDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<TodoItem?> GetById(TodoItemId id)
    {
        var results = await _dbContext.TodoItems
            .Include(i => i.Category)
            .FirstOrDefaultAsync(x => x.Id == id);

        return results;
    }

    public async Task<IEnumerable<TodoItem>> GetAll()
    {
        var results = await _dbContext.TodoItems
            .Include(i => i.Category)
            .ToListAsync();

        return results;
    }
    
    public async Task Add(TodoItem todoItem)
    {
        await _dbContext.TodoItems.AddAsync(todoItem);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task Update(TodoItem todoItem)
    {
        _dbContext.TodoItems.Update(todoItem);
        await _dbContext.SaveChangesAsync();
    }
}