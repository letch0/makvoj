using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Order
{
    public int PackageSchedules { get; set; }

    public int UserId { get; set; }

    public bool HasBeenPaid { get; set; }

    public virtual Package PackageSchedulesNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
