using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using TodoTaskManagement.Application.Features;
using TodoTaskManagement.Application.Features.GetTodoItems;
using TodoTaskManagement.Application.ResponseWrappers;

namespace TodoTaskManagement.API.Endpoints.v1;

public static class TodoItemEndpoints
{
    public static IEndpointRouteBuilder MapTodoItemEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("v1/todos", GetTodos)
        .WithOpenApi(cfg =>
        {
            cfg.OperationId = "GetTodoItems";
            cfg.Description = "Get all TodoItems";
            return cfg;
        })
        .Produces<Response<IEnumerable<TodoItemResult>>>(StatusCodes.Status200OK)
        .Produces<Response<IEnumerable<TodoItemResult>>>(StatusCodes.Status400BadRequest)
        .WithGroupName("v1");

        return endpoints;
    }

    public static async Task<Ok<Response<IEnumerable<TodoItemResult>>>> GetTodos(IMediator mediator)
    {
        var response = await mediator.Send(new GetTodoItemsQuery(),default);
            
        return TypedResults.Ok(response);
    }
}