using TodoTaskManagement.Domain.Abstracts;
using TodoTaskManagement.Domain.Exceptions;
using TodoTaskManagement.Domain.Identifiers;

namespace TodoTaskManagement.Domain;

public class TodoItem : BaseAggregateRoot<TodoItemId>
{
    private TodoItem()
    {
        
    }

    private TodoItem(string title, string description) 
    {
        SetTitle(title);
        SetDescription(description);
    }
    
    public string Title { get; private set; }
    
    public string Description { get; private set; }
    
    public TodoCategoryId? CategoryId { get; private set; }
    
    public TodoCategory? Category { get; private set; }
    

    public DateTime? DueDate { get; private set; }
    
    public DateTime? CompletedOn { get; private set; }
    
    public DateTime CreatedOn { get; private set; }

    public DateTime? UpdatedOn { get; private set; }

    public bool IsCompleted => CompletedOn is not null;

    public void Complete()
    {
        if (CompletedOn != default || CompletedOn is not null)
        {
            return;
        }
        
        var currentDate = DateTime.UtcNow;
        
        CompletedOn = currentDate;
        UpdatedOn = currentDate;
    }
    
    public void AssignCategory(TodoCategoryId categoryId)
    {
        CategoryId = categoryId;
    }

    public void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new InvalidTodoItemTitleException("A valid title value is required.");
        }
        
        Title = title;
    }
    
    public void SetDescription(string description)
    {
        Description = description;
    }
    
    public void SetDueDate(DateTime? dueDate)
    {
        if (dueDate is null)
        {
            return;
        }
        
        if (dueDate < DateTime.UtcNow)
        {
            throw new InvalidTodoItemDueDateException();
        }
        
        DueDate = dueDate;
    }

    public void Update(string title, string description)
    {
        SetTitle(title);
        Description = description;
        UpdatedOn = DateTime.UtcNow;
    }

    public static TodoItem Create(string title, string description)
    {
        var currentDate = DateTime.UtcNow;
        
        var todo = new TodoItem(
            title,
            description)
        {
            CreatedOn = currentDate
        };

        return todo;
    }
    
    public static TodoItem Create(string title, string description, TodoCategoryId? todoCategoryId)
    {
        var currentDate = DateTime.UtcNow;
        
        var todo = new TodoItem(
            title,
            description)
        {
            CreatedOn = currentDate
        };

        if (todoCategoryId is not null)
        {
            todo.AssignCategory(todoCategoryId);
        }

        return todo;
    }
}