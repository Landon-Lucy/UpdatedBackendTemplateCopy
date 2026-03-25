using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("employee_role", Schema = "rolebasedsecurity")]
public partial class EmployeeRole
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("role_id")]
    public int RoleId { get; set; }

    [Column("granted_date")]
    public DateOnly GrantedDate { get; set; }

    [Column("revoked_date")]
    public DateOnly? RevokedDate { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("EmployeeRoles")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("EmployeeRoles")]
    public virtual Role Role { get; set; } = null!;
}
