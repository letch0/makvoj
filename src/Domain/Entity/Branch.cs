using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Branch
{
    public int Id { get; set; }

    public int? Address { get; set; }

    public virtual Address? AddressNavigation { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
