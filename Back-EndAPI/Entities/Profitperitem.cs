using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Keyless]
public partial class Profitperitem
{
    [Column("id")]
    public int? Id { get; set; }

    [Column("ttlprofit", TypeName = "money")]
    public decimal? Ttlprofit { get; set; }
}
