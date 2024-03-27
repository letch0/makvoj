using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? PhoneNum { get; set; }

    public int? Addresses { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Address? AddressesNavigation { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
