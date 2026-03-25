using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("joke", Schema = "dadabase_f23")]
public partial class Joke
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("jokename", TypeName = "character varying")]
    public string? Jokename { get; set; }

    [Column("joketext")]
    [StringLength(128)]
    public string? Joketext { get; set; }

    [InverseProperty("Joke")]
    public virtual ICollection<Categorizedjoke> Categorizedjokes { get; set; } = new List<Categorizedjoke>();

    [InverseProperty("Joke")]
    public virtual ICollection<Deliveredjoke> Deliveredjokes { get; set; } = new List<Deliveredjoke>();
}
