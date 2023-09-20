namespace TodoTaskManagement.Domain.Abstracts;

public abstract class BaseEntity<TId>
{
    public TId? Id { get; protected set; }
    
    public override bool Equals(object obj)
    {
        var entity = obj as BaseEntity<TId>;
        return entity != null &&
               this.GetType() == entity.GetType() &&
               EqualityComparer<TId>.Default.Equals(Id, entity.Id);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(this.GetType(), Id);
    }

    public static bool operator ==(BaseEntity<TId> left, BaseEntity<TId> right)
    {
        return EqualityComparer<BaseEntity<TId>>.Default.Equals(left, right);
    }

    public static bool operator !=(BaseEntity<TId> left, BaseEntity<TId> right)
    {
        return !(left == right);
    }
}