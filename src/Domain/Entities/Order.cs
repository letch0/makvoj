using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[PrimaryKey("PackageSchedules", "UserId")]
[Table("orders")]
[Microsoft.EntityFrameworkCore.Index("UserId", Name = "userId")]
public partial class Order
{
    [Key]
    [Column("package_schedules")]
    public int PackageSchedules { get; set; }

    [Key]
    [Column("userId")]
    public int UserId { get; set; }

    [Column("has_been_paid")]
    public bool HasBeenPaid { get; set; }

    [ForeignKey("PackageSchedules")]
    [InverseProperty("Orders")]
    public virtual Package PackageSchedulesNavigation { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual User User { get; set; } = null!;
}
