using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("permission", Schema = "rolebasedsecurity")]
[Index("PermissionName", Name = "permission_permission_name_key", IsUnique = true)]
public partial class Permission
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("permission_name")]
    [StringLength(100)]
    public string PermissionName { get; set; } = null!;

    [Column("permission_description")]
    public string? PermissionDescription { get; set; }

    [InverseProperty("Permission")]
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
