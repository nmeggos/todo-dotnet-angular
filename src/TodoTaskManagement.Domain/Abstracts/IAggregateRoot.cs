using System.Collections.ObjectModel;

namespace TodoTaskManagement.Domain.Abstracts;

public interface IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent?> Events { get; }
    void ClearEvents();
}