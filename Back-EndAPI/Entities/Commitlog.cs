using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[PrimaryKey("Project", "Hash")]
[Table("commitlog", Schema = "chinook")]
public partial class Commitlog
{
    [Key]
    [Column("project")]
    public string Project { get; set; } = null!;

    [Key]
    [Column("hash")]
    public string Hash { get; set; } = null!;

    [Column("author")]
    public string? Author { get; set; }

    [Column("ats")]
    public DateTime? Ats { get; set; }

    [Column("committer")]
    public string? Committer { get; set; }

    [Column("cts")]
    public DateTime? Cts { get; set; }

    [Column("subject")]
    public string? Subject { get; set; }
}
