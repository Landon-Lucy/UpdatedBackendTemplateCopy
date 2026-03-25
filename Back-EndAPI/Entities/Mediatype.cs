using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("mediatype", Schema = "chinook")]
public partial class Mediatype
{
    [Key]
    [Column("mediatypeid")]
    public long Mediatypeid { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [InverseProperty("Mediatype")]
    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
