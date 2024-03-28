using Domain.Context;
using Domain.Entities;

namespace Business.Repositories;

public class AdminRepository: CRUDRepository<Admin>
{
    public AdminRepository(ApplicationDbContext context) : base(context)
    {
    }
}