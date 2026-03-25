using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("categorizedaudience", Schema = "dadabase_f23")]
public partial class Categorizedaudience
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("audienceid")]
    public int Audienceid { get; set; }

    [Column("audiencecategoryid")]
    public int Audiencecategoryid { get; set; }

    [ForeignKey("Audienceid")]
    [InverseProperty("Categorizedaudiences")]
    public virtual Audience Audience { get; set; } = null!;

    [ForeignKey("Audiencecategoryid")]
    [InverseProperty("Categorizedaudiences")]
    public virtual Audiencecategory Audiencecategory { get; set; } = null!;
}
