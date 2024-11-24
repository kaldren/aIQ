using aIQ.Domain.SharedKernel;
using aIQ.Domain.Users.Events;

namespace aIQ.Domain.Users;

public class User : BaseEntity<Guid>
{
    public FullName FullName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public void ChangePassword(string password)
    {
        Password = password;

        AddDomainEvent(new UserChangedPasswordDomainEvent());
    }

    public void ChangeEmail(string email)
    {
        Email = email;

        AddDomainEvent(new UserChangedEmailDomainEvent());
    }
}

public record FullName
{
    private string FirstName { get; }
    private string LastName { get; }

    public FullName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentNullException(nameof(firstName));
        }

        if (string.IsNullOrWhiteSpace(lastName)) {
            throw new ArgumentNullException(nameof(lastName));
        }

        if (firstName.Length < 2 || firstName.Length > 50)
        {
            throw new ArgumentException("First name must be between 2 and 50 characters.", nameof(firstName));
        }

        if (lastName.Length < 2 || lastName.Length > 50)
        {
            throw new ArgumentException("Last name must be between 2 and 50 characters.", nameof(lastName));
        }

        FirstName = firstName;
        LastName = lastName;
    }
}
