using System.Collections.Immutable;

namespace TodoTaskManagement.Domain.Abstracts;

public abstract class BaseAggregateRoot<TId> : BaseEntity<TId>, IAggregateRoot
{
    protected BaseAggregateRoot()
    {
        _events = new List<IDomainEvent?>();
    }

    private readonly IList<IDomainEvent?> _events;

    public IReadOnlyCollection<IDomainEvent?> Events => _events.ToImmutableArray();

    public void ClearEvents()
    {
        _events.Clear();
    }

    protected void AddEvent<TEvent>(TEvent @event) where TEvent : IDomainEvent
    {
        _events.Add(@event);
    }
}