using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class PackageSchedule
{
    public int Id { get; set; }

    public int PackageId { get; set; }

    public DateTime DateStart { get; set; }

    public short Days { get; set; }

    public virtual Package Package { get; set; } = null!;
}
