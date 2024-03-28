using Domain.Context;
using Domain.Entities;

namespace Business.Repositories;

public class BranchRepository :  CRUDRepository<Branch>
{
    public BranchRepository(ApplicationDbContext context) : base(context)
    {
    }
}