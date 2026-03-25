using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Keyless]
[Table("cars", Schema = "chinook")]
public partial class Car
{
    [Column("brand")]
    public string? Brand { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("color")]
    public int? Color { get; set; }

    [ForeignKey("Color")]
    public virtual Color? ColorNavigation { get; set; }
}
