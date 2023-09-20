namespace TodoTaskManagement.Application.Features.TodoItems.CreateTodoItem;

public class CreateTodoItemCommand : IRequest<Response<string>>
{
    public CreateTodoItemCommand()
    {
        
    }
    
    public string Title { get; set; }
    public string Description { get; set; }
    
    public int? CategoryId { get; set; }
}