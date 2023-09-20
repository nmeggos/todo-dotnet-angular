namespace TodoTaskManagement.Application.Features.TodoCategories.GetTodoCategory;

public class GetTodoCategoryQuery : IRequest<Response<TodoCategoryResult>>
{
    private GetTodoCategoryQuery()
    {
        
    }
    
    private GetTodoCategoryQuery(string? id)
    {
        Id = id;
    }

    public string? Id { get; set; }

    public static GetTodoCategoryQuery FromRequest(string? id) => new(id);
}