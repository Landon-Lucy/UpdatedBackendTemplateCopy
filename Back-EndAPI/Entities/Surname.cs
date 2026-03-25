using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Keyless]
[Table("surname", Schema = "census")]
public partial class Surname
{
    [Column("familysurname")]
    [StringLength(50)]
    public string? Familysurname { get; set; }
}
