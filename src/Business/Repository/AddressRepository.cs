using Domain.Context;
using Domain.Entity;

namespace Business.Repositories;

public class AddressRepository: CRUDRepository<Address>
{
    public AddressRepository(ApplicationDbContext context) : base(context)
    {
    }
}