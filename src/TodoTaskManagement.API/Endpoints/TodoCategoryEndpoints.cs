using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using TodoTaskManagement.Application.Features.TodoCategories.CreateTodoCategory;
using TodoTaskManagement.Application.Features.TodoCategories.GetTodoCategories;
using TodoTaskManagement.Application.Features.TodoCategories.GetTodoCategory;

namespace TodoTaskManagement.API.Endpoints;

public static class TodoCategoryEndpoints
{
    public static IEndpointRouteBuilder MapTodoCategoryEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/todos/categories")
            .WithOpenApi(cfg =>
            {
                cfg.Description = "Todo Categories";
                cfg.Tags = new List<OpenApiTag>()
                {
                    new() { Name = "Todo Categories" }
                };
                return cfg;
            });

        group.MapGet("/", async ([FromServices] IMediator mediator) =>
        {
            var response = await mediator.Send(new GetTodoCategoriesQuery());
            
            return Results.Ok(response);
        });
        
        group.MapGet("/{id}", async (
                [FromRoute] string? id,
                [FromServices] IMediator mediator) =>
        {
            var response = await mediator.Send(GetTodoCategoryQuery.FromRequest(id));

            return Results.Ok(response);
        });
        
        group.MapPost("/", async (
                [FromBody] CreateTodoCategoryCommand command, 
                [FromServices] IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            
            return Results.Created($"categories/{response.Data}", response);
        });
        
        return group;
    }
}