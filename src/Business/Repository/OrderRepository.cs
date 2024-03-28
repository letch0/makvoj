using Domain.Context;
using Domain.Entities;

namespace Business.Repositories;

public class OrderRepository : CRUDRepository<Order>
{
    public OrderRepository(ApplicationDbContext context) : base(context)
    {
    }
}