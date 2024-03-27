using Domain.Context;
using Domain.Entity;

namespace Business.Repositories;

public class DestinationRepository : CRUDRepository<Destination>
{
    public DestinationRepository(ApplicationDbContext context) : base(context)
    {
    }
}