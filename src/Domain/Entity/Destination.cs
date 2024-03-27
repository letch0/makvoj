using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Destination
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Address { get; set; }

    public string? Description { get; set; }

    public bool Availible { get; set; }

    public int? Rating { get; set; }

    public virtual Address AddressNavigation { get; set; } = null!;

    public virtual Photo? Photo { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
