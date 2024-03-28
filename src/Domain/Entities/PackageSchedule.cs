using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Table("package_schedules")]
[Microsoft.EntityFrameworkCore.Index("PackageId", Name = "package_id")]
public partial class PackageSchedule
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("package_id")]
    public int PackageId { get; set; }

    [Column("date_start", TypeName = "date")]
    public DateTime DateStart { get; set; }

    [Column("days")]
    public short Days { get; set; }

    [ForeignKey("PackageId")]
    [InverseProperty("PackageSchedules")]
    public virtual Package Package { get; set; } = null!;
}
