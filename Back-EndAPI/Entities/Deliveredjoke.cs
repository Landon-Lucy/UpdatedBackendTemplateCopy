using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("deliveredjoke", Schema = "dadabase_f23")]
public partial class Deliveredjoke
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("delivereddate")]
    public DateOnly? Delivereddate { get; set; }

    [Column("jokereactionid")]
    public int? Jokereactionid { get; set; }

    [Column("jokeid")]
    public int? Jokeid { get; set; }

    [Column("audienceid")]
    public int? Audienceid { get; set; }

    [Column("notes")]
    [StringLength(64)]
    public string? Notes { get; set; }

    [ForeignKey("Audienceid")]
    [InverseProperty("Deliveredjokes")]
    public virtual Audience? Audience { get; set; }

    [ForeignKey("Jokeid")]
    [InverseProperty("Deliveredjokes")]
    public virtual Joke? Joke { get; set; }

    [ForeignKey("Jokereactionid")]
    [InverseProperty("Deliveredjokes")]
    public virtual Jokereactioncategory? Jokereaction { get; set; }
}
