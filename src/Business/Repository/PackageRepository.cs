using Domain.Context;
using Domain.Entities;

namespace Business.Repositories;

public class PackageRepository : CRUDRepository<Package>
{
    public PackageRepository(ApplicationDbContext context) : base(context)
    {
    }
}