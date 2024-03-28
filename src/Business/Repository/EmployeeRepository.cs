using Domain.Context;
using Domain.Entities;

namespace Business.Repositories;

public class EmployeeRepository : CRUDRepository<Employee>
{
    public EmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }
}