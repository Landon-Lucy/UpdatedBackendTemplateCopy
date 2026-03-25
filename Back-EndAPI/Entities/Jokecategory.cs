using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("jokecategory", Schema = "dadabase_f23")]
public partial class Jokecategory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("categoryname", TypeName = "character varying")]
    public string? Categoryname { get; set; }

    [Column("description")]
    [StringLength(64)]
    public string? Description { get; set; }

    [InverseProperty("Jokecategory")]
    public virtual ICollection<Categorizedjoke> Categorizedjokes { get; set; } = new List<Categorizedjoke>();
}
