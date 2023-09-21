namespace TodoTaskManagement.Application.Features.TodoItems.CompleteTodoItem;

public class CompleteTodoItemCommand : IRequest<Response<string>>
{
    public CompleteTodoItemCommand()
    {
        
    }
    public string Id { get; set; }
}