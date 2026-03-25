using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("jokereactioncategory", Schema = "dadabase_f23")]
public partial class Jokereactioncategory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("reactionlevel")]
    [StringLength(16)]
    public string? Reactionlevel { get; set; }

    [Column("description")]
    [StringLength(64)]
    public string? Description { get; set; }

    [InverseProperty("Jokereaction")]
    public virtual ICollection<Deliveredjoke> Deliveredjokes { get; set; } = new List<Deliveredjoke>();
}
