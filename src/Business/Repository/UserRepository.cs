using Domain.Context;
using Domain.Entity;

namespace Business.Repositories;

public class UserRepository : CRUDRepository<User>
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}