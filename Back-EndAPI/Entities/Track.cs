using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("track", Schema = "chinook")]
[Index("Albumid", Name = "idx_17001_ifk_trackalbumid")]
[Index("Genreid", Name = "idx_17001_ifk_trackgenreid")]
[Index("Mediatypeid", Name = "idx_17001_ifk_trackmediatypeid")]
public partial class Track
{
    [Key]
    [Column("trackid")]
    public long Trackid { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("albumid")]
    public long? Albumid { get; set; }

    [Column("mediatypeid")]
    public long? Mediatypeid { get; set; }

    [Column("genreid")]
    public long? Genreid { get; set; }

    [Column("composer")]
    public string? Composer { get; set; }

    [Column("milliseconds")]
    public long? Milliseconds { get; set; }

    [Column("bytes")]
    public long? Bytes { get; set; }

    [Column("unitprice")]
    public decimal? Unitprice { get; set; }

    [ForeignKey("Albumid")]
    [InverseProperty("Tracks")]
    public virtual Album? Album { get; set; }

    [ForeignKey("Genreid")]
    [InverseProperty("Tracks")]
    public virtual Genre? Genre { get; set; }

    [InverseProperty("Track")]
    public virtual ICollection<Invoiceline> Invoicelines { get; set; } = new List<Invoiceline>();

    [ForeignKey("Mediatypeid")]
    [InverseProperty("Tracks")]
    public virtual Mediatype? Mediatype { get; set; }

    [ForeignKey("Trackid")]
    [InverseProperty("Tracks")]
    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}
