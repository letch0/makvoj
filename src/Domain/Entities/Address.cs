using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Table("addresses")]
public partial class Address
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("country")]
    [StringLength(64)]
    public string Country { get; set; } = null!;

    [Column("city")]
    [StringLength(128)]
    public string City { get; set; } = null!;

    [Column("street")]
    [StringLength(128)]
    public string Street { get; set; } = null!;

    [Column("street2")]
    [StringLength(128)]
    public string? Street2 { get; set; }

    [Column("postal_code")]
    [StringLength(10)]
    public string? PostalCode { get; set; }

    [InverseProperty("AddressNavigation")]
    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    [InverseProperty("AddressNavigation")]
    public virtual ICollection<Destination> Destinations { get; set; } = new List<Destination>();

    [InverseProperty("AddressesNavigation")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
