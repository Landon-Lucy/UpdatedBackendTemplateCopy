using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("character")]
public partial class Character
{
    [Key]
    [Column("hero_id")]
    public Guid HeroId { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("class")]
    [StringLength(30)]
    public string Class { get; set; } = null!;

    [Column("level")]
    public int Level { get; set; }

    [Column("health")]
    public int Health { get; set; }

    [Column("mana")]
    public int Mana { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }
}
