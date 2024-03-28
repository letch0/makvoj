using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Table("tags")]
public partial class Tag
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(64)]
    public string Name { get; set; } = null!;

    [Column("decription", TypeName = "text")]
    public string? Decription { get; set; }

    [ForeignKey("TagsId")]
    [InverseProperty("Tags")]
    public virtual ICollection<Destination> Destinations { get; set; } = new List<Destination>();

    [ForeignKey("TagsId")]
    [InverseProperty("Tags")]
    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();

    [ForeignKey("TagsId")]
    [InverseProperty("Tags")]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
