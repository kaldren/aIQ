namespace aIQ.Domain.SharedKernel;

public abstract class BaseEvent
{
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}