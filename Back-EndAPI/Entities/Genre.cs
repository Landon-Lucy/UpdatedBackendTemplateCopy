using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("genre", Schema = "chinook")]
public partial class Genre
{
    [Key]
    [Column("genreid")]
    public long Genreid { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [InverseProperty("Genre")]
    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
