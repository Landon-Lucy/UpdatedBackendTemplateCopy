using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("AspNetUserClaims", Schema = "f25election")]
[Index("UserId", Name = "IX_AspNetUserClaims_UserId")]
public partial class AspNetUserClaim1
{
    [Key]
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("AspNetUserClaim1s")]
    public virtual AspNetUser1 User { get; set; } = null!;
}
