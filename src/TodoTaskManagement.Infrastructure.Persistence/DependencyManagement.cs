using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoTaskManagement.Domain.Interfaces;

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

        return services;
    }
}