using TodoTaskManagement.Application.ResponseWrappers;

namespace TodoTaskManagement.Application.Features.TodoItems.GetTodoItems;

public class GetTodoItemsQuery : IRequest<Response<IEnumerable<TodoItemResult>>>
{
    
}