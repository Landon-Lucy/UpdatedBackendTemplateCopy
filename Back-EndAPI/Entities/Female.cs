using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Keyless]
[Table("female", Schema = "census")]
public partial class Female
{
    [Column("givenname")]
    [StringLength(50)]
    public string? Givenname { get; set; }
}
