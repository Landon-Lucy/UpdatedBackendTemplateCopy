using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[PrimaryKey("LoginProvider", "ProviderKey")]
[Table("AspNetUserLogins", Schema = "f25election")]
[Index("UserId", Name = "IX_AspNetUserLogins_UserId")]
public partial class AspNetUserLogin1
{
    [Key]
    public string LoginProvider { get; set; } = null!;

    [Key]
    public string ProviderKey { get; set; } = null!;

    public string? ProviderDisplayName { get; set; }

    public string UserId { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("AspNetUserLogin1s")]
    public virtual AspNetUser1 User { get; set; } = null!;
}
