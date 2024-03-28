using Domain.Context;
using Domain.Entities;

namespace Business.Repositories;

public class PackageSheduleRepository : CRUDRepository<PackageSchedule>
{
    public PackageSheduleRepository(ApplicationDbContext context) : base(context)
    {
    }
}