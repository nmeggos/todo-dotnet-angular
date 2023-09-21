using TodoTaskManagement.Domain.Exceptions;

namespace TodoTaskManagement.Domain;

public record TodoItemId : IParsable<TodoItemId>
{
    private TodoItemId(int value)
    {
        Value = value;
    }

    public int Value { get; private set; }
    
    public static TodoItemId From(int value) => new(value);

    public static TodoItemId From(int? value) =>
        value is null
            ? new TodoItemId(0)
            : new TodoItemId((int)value);

    public static TodoItemId From(string? value) => Parse(value);

    public static implicit operator int(TodoItemId id) => id.Value;
    
    public override string ToString() => Value.ToString();
    public static TodoItemId Parse(string? s, IFormatProvider? provider = null)
    {
        return int.TryParse(s, out var value) 
            ? new TodoItemId(value) 
            : new TodoItemId(0);
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out TodoItemId result)
    {
        if (int.TryParse(s, out var value))
        {
            result = new TodoItemId(value);
            return true;
        }

        result = new TodoItemId(0);
        return false;
    }
}