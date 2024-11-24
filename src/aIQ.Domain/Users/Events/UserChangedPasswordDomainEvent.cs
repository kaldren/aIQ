using aIQ.Domain.SharedKernel;
using System.Diagnostics;

namespace aIQ.Domain.Users.Events;

public class UserChangedPasswordDomainEvent : BaseEvent
{
    public UserChangedPasswordDomainEvent()
    {
        Debug.WriteLine($"User changed their password at {base.OccurredOn}");
    }
}
