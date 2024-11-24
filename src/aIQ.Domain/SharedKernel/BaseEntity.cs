namespace aIQ.Domain.SharedKernel;

public abstract class BaseEntity<T> where T : struct
{
    private List<BaseEvent> _domainEvents;

    public T Id { get; protected set; }

    /// <summary>
    /// Domain events occurred.
    /// </summary>
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents?.AsReadOnly();

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    /// <summary>
    /// Add domain event.
    /// </summary>
    /// <param name="domainEvent">Domain event.</param>
    protected void AddDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents ??= [];

        this._domainEvents.Add(domainEvent);
    }
}
