using TodoTaskManagement.Domain.Exceptions;

namespace TodoTaskManagement.Domain;

public class TodoItem
{
    private TodoItem()
    {
        
    }
    
    public TodoItem(TodoItemId id,
        string title,
        string description)
    {
        Id = id;
        SetTitle(title);
        Description = description;
    }

    public TodoItemId Id { get; private set; }
    
    public string Title { get; private set; }
    
    public string Description { get; private set; }
    
    public DateTime CreatedOn { get; private set; }
    
    public DateTime? UpdatedOn { get; private set; }
    
    public DateTime? CompletedOn { get; private set; }

    public bool IsCompleted { get; private set; }

    public void Complete()
    {
        if (CompletedOn != default || CompletedOn is not null)
        {
            return;
        }
        
        var currentDate = DateTime.UtcNow;
        
        CompletedOn = currentDate;
        UpdatedOn = currentDate;
        IsCompleted = true;
    }
    
    public void Update(string title, string description)
    {
        SetTitle(title);
        Description = description;
        UpdatedOn = DateTime.UtcNow;
    }
    
    private void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new InvalidTodoItemTitleException("A valid title value is required.");
        }
        
        Title = title;
    }
    
    public static TodoItem Create(string title, string description)
    {
        var currentDate = DateTime.UtcNow;
        
        return new TodoItem(
            TodoItemId.New(),
            title,
            description)
        {
            CreatedOn = currentDate
        };
    }
}