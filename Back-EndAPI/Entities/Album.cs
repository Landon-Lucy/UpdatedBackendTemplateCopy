using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("album", Schema = "chinook")]
[Index("Artistid", Name = "idx_16944_ifk_albumartistid")]
public partial class Album
{
    [Key]
    [Column("albumid")]
    public long Albumid { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    [Column("artistid")]
    public long? Artistid { get; set; }

    [ForeignKey("Artistid")]
    [InverseProperty("Albums")]
    public virtual Artist? Artist { get; set; }

    [InverseProperty("Album")]
    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
