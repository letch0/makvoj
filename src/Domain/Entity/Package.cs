using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Package
{
    public int Id { get; set; }

    public int Room { get; set; }

    public bool? Availible { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? RootPackageId { get; set; }

    public virtual Admin CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Package> InverseRootPackage { get; set; } = new List<Package>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PackageSchedule> PackageSchedules { get; set; } = new List<PackageSchedule>();

    public virtual Room RoomNavigation { get; set; } = null!;

    public virtual Package? RootPackage { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
