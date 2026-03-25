using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("audience", Schema = "dadabase_f23")]
public partial class Audience
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("audiencename", TypeName = "character varying")]
    public string? Audiencename { get; set; }

    [Column("description")]
    [StringLength(64)]
    public string? Description { get; set; }

    [InverseProperty("Audience")]
    public virtual ICollection<Categorizedaudience> Categorizedaudiences { get; set; } = new List<Categorizedaudience>();

    [InverseProperty("Audience")]
    public virtual ICollection<Deliveredjoke> Deliveredjokes { get; set; } = new List<Deliveredjoke>();
}
