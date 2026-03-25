using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("categorizedjoke", Schema = "dadabase_f23")]
public partial class Categorizedjoke
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("jokeid")]
    public int? Jokeid { get; set; }

    [Column("jokecategoryid")]
    public int? Jokecategoryid { get; set; }

    [ForeignKey("Jokeid")]
    [InverseProperty("Categorizedjokes")]
    public virtual Joke? Joke { get; set; }

    [ForeignKey("Jokecategoryid")]
    [InverseProperty("Categorizedjokes")]
    public virtual Jokecategory? Jokecategory { get; set; }
}
