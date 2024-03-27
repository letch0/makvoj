using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Photo
{
    public int Id { get; set; }

    public byte[] Photo1 { get; set; } = null!;

    public virtual Destination IdNavigation { get; set; } = null!;

    public virtual ICollection<Destination> Destinations { get; set; } = new List<Destination>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
