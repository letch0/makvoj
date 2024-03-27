using Domain.Context;
using Domain.Entity;

namespace Business.Repositories;

public class PhotoRepository : CRUDRepository<Photo>
{
    public PhotoRepository(ApplicationDbContext context) : base(context)
    {
    }
}