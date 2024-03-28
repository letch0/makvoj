using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Table("photos")]
public partial class Photo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("photo", TypeName = "blob")]
    public byte[] Photo1 { get; set; } = null!;

    [ForeignKey("Id")]
    [InverseProperty("Photo")]
    public virtual Destination IdNavigation { get; set; } = null!;

    [ForeignKey("PhotosId")]
    [InverseProperty("Photos")]
    public virtual ICollection<Destination> Destinations { get; set; } = new List<Destination>();

    [ForeignKey("PhotosId")]
    [InverseProperty("Photos")]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
