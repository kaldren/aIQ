using aIQ.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace aIQ.Application.Common;

public interface IAppDbContext
{
    public DbSet<User> Users { get; set; }
}
