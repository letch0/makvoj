using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Admin
{
    public int Id { get; set; }

    public bool CanEdit { get; set; }

    public bool CanDelete { get; set; }

    public virtual Employee IdNavigation { get; set; } = null!;

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();
}
