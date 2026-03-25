using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("playlist", Schema = "chinook")]
public partial class Playlist
{
    [Key]
    [Column("playlistid")]
    public long Playlistid { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [ForeignKey("Playlistid")]
    [InverseProperty("Playlists")]
    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
