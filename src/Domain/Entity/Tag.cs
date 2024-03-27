using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Tag
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Decription { get; set; }

    public virtual ICollection<Destination> Destinations { get; set; } = new List<Destination>();

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
