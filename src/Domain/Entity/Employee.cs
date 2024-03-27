using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Employee
{
    public int Id { get; set; }

    public int? Branch { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual Branch? BranchNavigation { get; set; }

    public virtual User IdNavigation { get; set; } = null!;
}
