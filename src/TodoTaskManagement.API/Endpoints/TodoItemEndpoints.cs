using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoTaskManagement.Application.Features;
using TodoTaskManagement.Application.Features.CreateTodoItem;
using TodoTaskManagement.Application.Features.GetTodoItem;
using TodoTaskManagement.Application.Features.GetTodoItems;
using TodoTaskManagement.Application.ResponseWrappers;

namespace TodoTaskManagement.API.Endpoints;

public static class TodoItemEndpoints
{
    public static IEndpointRouteBuilder MapTodoItemEndpoints(this IEndpointRouteBuilder endpoints)
    {   
        endpoints.MapGet("todos",
                async ([FromServices] IMediator mediator) =>
                {
                    var response = await mediator.Send(new GetTodoItemsQuery());

                    return Results.Ok(response);
                })
            .WithOpenApi(cfg =>
            {
                cfg.OperationId = "GetTodoItems";
                cfg.Description = "Get all TodoItems";
                return cfg;
            })
            .Produces<Response<IEnumerable<TodoItemResult>>>(StatusCodes.Status200OK)
            .Produces<Response<IEnumerable<TodoItemResult>>>(StatusCodes.Status400BadRequest)
            .WithGroupName("v1");

        endpoints.MapGet("todos/{id}", async (
                [FromRoute] string id,
                [FromServices] IMediator mediator) =>
        {
            var response = await mediator.Send(GetTodoItemQuery.FromRequest(id));

            return Results.Ok(response);
        })
            .WithOpenApi(cfg =>
            {
                cfg.OperationId = "GetTodoItem";
                cfg.Description = "Get TodoItem by id";
                return cfg;
            });
        
        endpoints.MapPost("todos",
                async (
                    [FromBody] CreateTodoItemCommand command, 
                    [FromServices] IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    
                    return Results.Created($"todos/{response.Data}", response);
                })
            .WithOpenApi(cfg =>
            {
                cfg.OperationId = "CreateTodoItem";
                cfg.Description = "Create Todo Item";
                return cfg;
            })
            .Produces<Response<string>>(StatusCodes.Status201Created)
            .Produces<Response<string>>(StatusCodes.Status400BadRequest)
            .WithGroupName("v1");
        
        return endpoints;
    }
}