using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Keyless]
[Table("dump_class_shared_ro", Schema = "f25election")]
public partial class DumpClassSharedRo
{
    [Column("--")]
    [StringLength(8000)]
    public string? _ { get; set; }
}
