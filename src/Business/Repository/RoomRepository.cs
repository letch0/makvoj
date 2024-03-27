using Domain.Context;
using Domain.Entity;

namespace Business.Repositories;

public class RoomRepository : CRUDRepository<Room>
{
    public RoomRepository(ApplicationDbContext context) : base(context)
    {
    }
}