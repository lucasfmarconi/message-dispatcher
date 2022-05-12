namespace MessageDispatcher.Domain;

public abstract class Entity
{
    private List<IDomainNotification> domainEvents;
    public IReadOnlyCollection<IDomainNotification> DomainEvents => domainEvents?.AsReadOnly();
    public Guid Id { get; private init; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }
    public void AddDomainEvent(IDomainNotification eventItem)
    {
        domainEvents ??= new List<IDomainNotification>();
        domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(IDomainNotification eventItem)
    {
        domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        domainEvents?.Clear();
    }
}