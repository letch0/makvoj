using Domain.Context;
using Domain.Entity;

namespace Business.Repositories;

public class OrderRepository : CRUDRepository<Order>
{
    public OrderRepository(ApplicationDbContext context) : base(context)
    {
    }
}