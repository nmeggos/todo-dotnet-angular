namespace TodoTaskManagement.Application.Features.TodoCategories.CreateTodoCategory;

public class CreateTodoCategoryCommand : IRequest<Response<string>>
{
    public CreateTodoCategoryCommand()
    {
        
    }
    
    public string Name { get; set; }
}