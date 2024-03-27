using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Room
{
    public int Id { get; set; }

    public int Destination { get; set; }

    public string? Description { get; set; }

    public string Beds { get; set; } = null!;

    public bool? Availible { get; set; }

    public int? AmountAvailible { get; set; }

    public decimal CostPerNight { get; set; }

    public virtual Destination DestinationNavigation { get; set; } = null!;

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
