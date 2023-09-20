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
    public static implicit operator TodoCategoryId(int id) => new(id);

    public static TodoCategoryId From(string id)
    {
        if (int.TryParse(id, out var value))
        {
            return new TodoCategoryId(value);
        }
        
        throw new InvalidTodoCategoryIdException("Invalid TodoCategoryId value.");
    }
    
    public static TodoCategoryId From(int id)
    {
        return new(id);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}