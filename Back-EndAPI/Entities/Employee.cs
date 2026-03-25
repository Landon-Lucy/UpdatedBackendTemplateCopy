using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("employee", Schema = "rolebasedsecurity")]
[Index("Ssn", Name = "employee_ssn_key", IsUnique = true)]
public partial class Employee
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("birthdate")]
    public DateOnly Birthdate { get; set; }

    [Column("ssn")]
    [StringLength(11)]
    public string Ssn { get; set; } = null!;

    [Column("hiredate")]
    public DateOnly Hiredate { get; set; }

    [Column("terminationdate")]
    public DateOnly? Terminationdate { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; } = new List<EmployeeRole>();
}
