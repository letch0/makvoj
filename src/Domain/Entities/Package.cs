using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Table("packages")]
[Microsoft.EntityFrameworkCore.Index("CreatedBy", Name = "created_by")]
[Microsoft.EntityFrameworkCore.Index("Room", Name = "room")]
[Microsoft.EntityFrameworkCore.Index("RootPackageId", Name = "root_package_id")]
public partial class Package
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("room")]
    public int Room { get; set; }

    [Required]
    [Column("availible")]
    public bool? Availible { get; set; }

    [Column("created_by")]
    public int CreatedBy { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("deleted_at", TypeName = "timestamp")]
    public DateTime? DeletedAt { get; set; }

    [Column("root_package_id")]
    public int? RootPackageId { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("Packages")]
    public virtual Admin CreatedByNavigation { get; set; } = null!;

    [InverseProperty("RootPackage")]
    public virtual ICollection<Package> InverseRootPackage { get; set; } = new List<Package>();

    [InverseProperty("PackageSchedulesNavigation")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Package")]
    public virtual ICollection<PackageSchedule> PackageSchedules { get; set; } = new List<PackageSchedule>();

    [ForeignKey("Room")]
    [InverseProperty("Packages")]
    public virtual Room RoomNavigation { get; set; } = null!;

    [ForeignKey("RootPackageId")]
    [InverseProperty("InverseRootPackage")]
    public virtual Package? RootPackage { get; set; }

    [ForeignKey("PackagesId")]
    [InverseProperty("Packages")]
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
