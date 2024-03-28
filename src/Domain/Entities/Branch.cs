using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Table("branches")]
[Microsoft.EntityFrameworkCore.Index("Address", Name = "address")]
public partial class Branch
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("address")]
    public int? Address { get; set; }

    [ForeignKey("Address")]
    [InverseProperty("Branches")]
    public virtual Address? AddressNavigation { get; set; }

    [InverseProperty("BranchNavigation")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
