using Domain.Context;
using Domain.Entity;

namespace Business.Repositories;

public class PackageRepository : CRUDRepository<Package>
{
    public PackageRepository(ApplicationDbContext context) : base(context)
    {
    }
}