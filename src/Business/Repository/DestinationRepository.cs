using Domain.Context;
using Domain.Entities;

namespace Business.Repositories;

public class DestinationRepository : CRUDRepository<Destination>
{
    public DestinationRepository(ApplicationDbContext context) : base(context)
    {
    }
}