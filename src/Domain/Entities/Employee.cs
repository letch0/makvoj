using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Table("employees")]
[Microsoft.EntityFrameworkCore.Index("Branch", Name = "branch")]
public class Employee : User
{
    [Column("branch")]
    public int? Branch { get; set; }

    [ForeignKey("Branch")]
    [InverseProperty("Employees")]
    public virtual Branch? BranchNavigation { get; set; }
}
