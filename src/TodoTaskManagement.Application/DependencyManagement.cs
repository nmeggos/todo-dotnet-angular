using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace TodoTaskManagement.Application;

public static class DependencyManagement
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assemblyReference = typeof(AssemblyReference).Assembly;

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
        );
        
        return services;
    }
}