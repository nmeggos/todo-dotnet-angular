using TodoTaskManagement.Application.ResponseWrappers;

namespace TodoTaskManagement.Application.Features.TodoItems.GetTodoItem;

public class GetTodoItemQuery : IRequest<Response<TodoItemResult>>
{
    private GetTodoItemQuery()
    {
        
    }
    
    private GetTodoItemQuery(string id)
    {
        Id = id;
    }

    public string Id { get; private set; }
    
    public static GetTodoItemQuery FromRequest(string id) => new(id);
}