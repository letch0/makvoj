using Domain.Context;
using Domain.Entity;

namespace Business.Repositories;

public class TagRepository : CRUDRepository<Tag>
{
    public TagRepository(ApplicationDbContext context) : base(context)
    {
    }
}