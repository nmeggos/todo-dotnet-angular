using TodoTaskManagement.Application.Features.TodoCategories;

namespace TodoTaskManagement.Application.Features.TodoItems;

public class TodoItemResult
{
    private TodoItemResult()
    {
        
    }
    
    public string Id { get; private set; }
    
    public string Title { get; private set; }
    
    public string Description { get; private set; }
    
    public TodoCategoryResult? Category { get; private set; }
    
    public DateTime CreatedOn { get; private set; }
    
    public DateTime? UpdatedOn { get; private set; }
    
    public DateTime? CompletedOn { get; private set; }

    public bool IsCompleted { get; private set; }
}