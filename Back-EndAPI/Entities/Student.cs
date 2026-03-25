using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("student")]
public partial class Student
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(40)]
    public string? Name { get; set; }

    [Column("phone")]
    [StringLength(10)]
    public string? Phone { get; set; }
}
