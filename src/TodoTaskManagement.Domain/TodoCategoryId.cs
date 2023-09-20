using TodoTaskManagement.Domain.Exceptions;

namespace TodoTaskManagement.Domain;

public record TodoCategoryId
{
    private TodoCategoryId(int value)
    {
        Value = value;
    }

    public int Value { get; }
    
    public static implicit operator int(TodoCategoryId id) => id.Value;

    public static TodoCategoryId From(string? id)
    {
        if (int.TryParse(id, out var value))
        {
            return new TodoCategoryId(value);
        }

        return new TodoCategoryId(0);
    }
    
    public static TodoCategoryId From(int id)
    {
        return new(id);
    }
    
    public static TodoCategoryId From(int? id)
    {
        if (id is null)
        {
            return new(0);
        }
        
        return new((int)id);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}