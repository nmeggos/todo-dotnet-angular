using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoTaskManagement.Domain.Interfaces;
using TodoTaskManagement.Infrastructure.Persistence.Repositories;

namespace TodoTaskManagement.Infrastructure.Persistence;

public static class DependencyManagement
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("TodoDb");
        
        services.AddDbContext<TodoDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<ITodoItemRepository, TodoItemRepository>();
        services.AddScoped<ITodoCategoryRepository, TodoCategoryRepository>();

        return services;
    }
}