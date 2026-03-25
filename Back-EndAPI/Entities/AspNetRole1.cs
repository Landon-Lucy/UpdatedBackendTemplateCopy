using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("AspNetRoles", Schema = "f25election")]
[Index("NormalizedName", Name = "RoleNameIndex", IsUnique = true)]
public partial class AspNetRole1
{
    [Key]
    public string Id { get; set; } = null!;

    [StringLength(256)]
    public string? Name { get; set; }

    [StringLength(256)]
    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<AspNetRoleClaim1> AspNetRoleClaim1s { get; set; } = new List<AspNetRoleClaim1>();

    [ForeignKey("RoleId")]
    [InverseProperty("Roles")]
    public virtual ICollection<AspNetUser1> Users { get; set; } = new List<AspNetUser1>();
}
