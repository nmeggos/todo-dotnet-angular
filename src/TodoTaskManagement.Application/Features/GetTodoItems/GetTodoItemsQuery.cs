using TodoTaskManagement.Application.ResponseWrappers;

namespace TodoTaskManagement.Application.Features.GetTodoItems;

public class GetTodoItemsQuery : IRequest<Response<IEnumerable<TodoItemResult>>>
{
    
}