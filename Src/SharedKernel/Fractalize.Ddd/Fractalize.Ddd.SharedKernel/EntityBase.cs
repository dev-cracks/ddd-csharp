namespace Fractalize.Ddd.SharedKernel;

/// <summary>
/// Serves as a base class for all entities in the application, providing a common foundation for derived entity types.
/// </summary>
/// <remarks>This class is intended to be inherited by other entity classes, which will implement specific
/// behaviors and properties relevant to their context. It may include common functionality or properties that all
/// entities share, such as identifiers or state management.</remarks>
public abstract class EntityBase<TId>
{
    public required TId Id { get; set; }

    private readonly List<DomainEventBase> _domainEvents = [];

    public IReadOnlyCollection<DomainEventBase> DomainEvents => _domainEvents;

    public void AddDomainEvent(DomainEventBase domainEvent) => 
        _domainEvents.Add(domainEvent);

    public void ClearDomainEvents(DomainEventBase domainEvent) =>
        _domainEvents.Add(domainEvent);
}