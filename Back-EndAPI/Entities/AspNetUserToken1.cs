using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[PrimaryKey("UserId", "LoginProvider", "Name")]
[Table("AspNetUserTokens", Schema = "f25election")]
public partial class AspNetUserToken1
{
    [Key]
    public string UserId { get; set; } = null!;

    [Key]
    public string LoginProvider { get; set; } = null!;

    [Key]
    public string Name { get; set; } = null!;

    public string? Value { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("AspNetUserToken1s")]
    public virtual AspNetUser1 User { get; set; } = null!;
}
