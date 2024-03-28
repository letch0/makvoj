using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Table("rooms")]
[Microsoft.EntityFrameworkCore.Index("Destination", Name = "destination")]
public partial class Room
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("destination")]
    public int Destination { get; set; }

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("beds", TypeName = "json")]
    public string Beds { get; set; } = null!;

    [Required]
    [Column("availible")]
    public bool? Availible { get; set; }

    [Column("amount_availible")]
    public int? AmountAvailible { get; set; }

    [Column("cost_per_night")]
    [Precision(15)]
    public decimal CostPerNight { get; set; }

    [ForeignKey("Destination")]
    [InverseProperty("Rooms")]
    public virtual Destination DestinationNavigation { get; set; } = null!;

    [InverseProperty("RoomNavigation")]
    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();

    [ForeignKey("RoomsId")]
    [InverseProperty("Rooms")]
    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    [ForeignKey("RoomsId")]
    [InverseProperty("Rooms")]
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
