
namespace TodoTaskManagement.Infrastructure.Persistence.Repositories;

public class TodoCategoryRepository : ITodoCategoryRepository
{
    private readonly TodoDbContext _dbContext;

    public TodoCategoryRepository(TodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<TodoCategory>> GetAllAsync()
    {
        var results = await _dbContext.TodoCategories
            .ToListAsync();
        
        return results;
    }

    public async Task<TodoCategory> GetByIdAsync(TodoCategoryId id)
    {
        var result = await _dbContext.TodoCategories.FindAsync(id);

        return result;
    }

    public async Task<TodoCategoryId?> AddAsync(TodoCategory category)
    {
        var result = await _dbContext.TodoCategories.AddAsync(category);
        await _dbContext.SaveChangesAsync();

        return result.Entity.Id; 
    }

    public Task UpdateAsync(TodoCategory category)
    {
        _dbContext.TodoCategories.Update(category);
        return _dbContext.SaveChangesAsync();
    }
}