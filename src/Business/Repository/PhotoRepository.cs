using Domain.Context;
using Domain.Entities;

namespace Business.Repositories;

public class PhotoRepository : CRUDRepository<Photo>
{
    public PhotoRepository(ApplicationDbContext context) : base(context)
    {
    }
}