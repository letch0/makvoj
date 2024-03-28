using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Table("destinations")]
[Microsoft.EntityFrameworkCore.Index("Address", Name = "address")]
public partial class Destination
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(128)]
    public string Name { get; set; } = null!;

    [Column("address")]
    public int Address { get; set; }

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("availible")]
    public bool Availible { get; set; }

    [Column("rating")]
    public int? Rating { get; set; }

    [ForeignKey("Address")]
    [InverseProperty("Destinations")]
    public virtual Address AddressNavigation { get; set; } = null!;

    [InverseProperty("IdNavigation")]
    public virtual Photo? Photo { get; set; }

    [InverseProperty("DestinationNavigation")]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    [ForeignKey("DestinationsId")]
    [InverseProperty("Destinations")]
    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    [ForeignKey("DestinationsId")]
    [InverseProperty("Destinations")]
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
