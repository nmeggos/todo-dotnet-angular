using TodoTaskManagement.Domain.Exceptions;

namespace TodoTaskManagement.Domain;

public record TodoItemId
{
    private TodoItemId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }
    
    public static TodoItemId New() => new(Guid.NewGuid());
    public static TodoItemId From(Guid value) => new(value);
    public static TodoItemId From(string value)
    {
        if (!Guid.TryParse(value, out var _))
        {
            throw new InvalidTodoItemIdException(value);
        }
        
        return new TodoItemId(Guid.Parse(value));
    }

    public static implicit operator Guid(TodoItemId todoItemId) => todoItemId.Value;
    
    public override string ToString() => Value.ToString();
}