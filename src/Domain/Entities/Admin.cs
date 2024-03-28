using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Table("admin")]
public partial class Admin : Employee
{
    [Column("can_edit")]
    public bool CanEdit { get; set; }

    [Column("can_delete")]
    public bool CanDelete { get; set; }

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();
}
