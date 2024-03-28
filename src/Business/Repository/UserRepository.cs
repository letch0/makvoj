using Domain.Context;
using Domain.Entities;

namespace Business.Repositories;

public class UserRepository : CRUDRepository<User>
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}