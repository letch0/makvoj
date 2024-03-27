using Domain.Context;
using Domain.Entity;

namespace Business.Repositories;

public class PackageSheduleRepository : CRUDRepository<PackageSchedule>
{
    public PackageSheduleRepository(ApplicationDbContext context) : base(context)
    {
    }
}