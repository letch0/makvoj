using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Table("users")]
[Microsoft.EntityFrameworkCore.Index("Addresses", Name = "addresses")]
[Microsoft.EntityFrameworkCore.Index("Email", Name = "users_index_0")]
public partial class User : IdentityUser<int>
{
    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("surname")]
    [StringLength(255)]
    public string Surname { get; set; } = null!;

    [Column("addresses")]
    public int? Addresses { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("Addresses")]
    [InverseProperty("Users")]
    public virtual Address? AddressesNavigation { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
