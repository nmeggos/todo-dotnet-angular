using TodoTaskManagement.Domain.Abstracts;
using TodoTaskManagement.Domain.Identifiers;

namespace TodoTaskManagement.Domain;

public class TodoCategory : BaseAggregateRoot<TodoCategoryId>
{
    private TodoCategory()
    {
        
    }
    
    private TodoCategory(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
    
    public void Update(string name)
    {
        Name = name;
    }
    
    public static TodoCategory Create(string name)
    {
        return new(name);
    }
}