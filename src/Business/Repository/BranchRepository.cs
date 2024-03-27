using Domain.Context;
using Domain.Entity;

namespace Business.Repositories;

public class BranchRepository :  CRUDRepository<Branch>
{
    public BranchRepository(ApplicationDbContext context) : base(context)
    {
    }
}