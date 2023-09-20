namespace TodoTaskManagement.Infrastructure.Persistence;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<TodoCategory> TodoCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoItemEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TodoCategoryEntityTypeConfiguration());
    }
}