using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Address
{
    public int Id { get; set; }

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string? Street2 { get; set; }

    public string? PostalCode { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<Destination> Destinations { get; set; } = new List<Destination>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
