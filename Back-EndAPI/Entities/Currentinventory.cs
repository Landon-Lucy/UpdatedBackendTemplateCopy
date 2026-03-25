using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Keyless]
public partial class Currentinventory
{
    [Column("id")]
    public int? Id { get; set; }

    [Column("numinstock")]
    public long? Numinstock { get; set; }
}
