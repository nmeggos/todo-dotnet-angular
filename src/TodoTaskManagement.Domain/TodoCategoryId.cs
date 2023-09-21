namespace TodoTaskManagement.Domain;

public record TodoCategoryId : IParsable<TodoCategoryId>
{
    private TodoCategoryId(int value)
    {
        Value = value;
    }

    public int Value { get; }
    
    public static implicit operator int(TodoCategoryId id) => id.Value;

    public static TodoCategoryId From(string? id) => Parse(id);

    public static TodoCategoryId From(int id)
    {
        return new(id);
    }
    
    public static TodoCategoryId From(int? id) =>
        id is null 
            ? new(0) 
            : new((int)id);

    public override string ToString()
    {
        return Value.ToString();
    }

    public static TodoCategoryId Parse(string? s, IFormatProvider? provider = null)
    {
        return int.TryParse(s, out var value) 
            ? new TodoCategoryId(value) 
            : new TodoCategoryId(0);
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out TodoCategoryId result)
    {
        if (int.TryParse(s, out var value))
        {
            result = new TodoCategoryId(value);
            return true;
        }

        result = new TodoCategoryId(0);
        return false;
    }
}