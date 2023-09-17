
namespace TodoTaskManagement.Infrastructure.Persistence;

public class TodoItemRepository : ITodoItemRepository
{
    private readonly TodoDbContext _dbContext;

    public TodoItemRepository(TodoDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<TodoItem?> Get(TodoItemId id)
    {
        var results = await _dbContext.TodoItems.FindAsync(id);

        return results;
    }

    public async Task<IEnumerable<TodoItem>> GetAll()
    {
        var results = await _dbContext.TodoItems.ToListAsync();

        return results;
    }
}