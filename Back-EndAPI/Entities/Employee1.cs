using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("employee", Schema = "chinook")]
[Index("Reportsto", Name = "idx_16962_ifk_employeereportsto")]
public partial class Employee1
{
    [Key]
    [Column("employeeid")]
    public long Employeeid { get; set; }

    [Column("lastname")]
    public string? Lastname { get; set; }

    [Column("firstname")]
    public string? Firstname { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    [Column("reportsto")]
    public long? Reportsto { get; set; }

    [Column("birthdate")]
    public DateTime? Birthdate { get; set; }

    [Column("hiredate")]
    public DateTime? Hiredate { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("city")]
    public string? City { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("country")]
    public string? Country { get; set; }

    [Column("postalcode")]
    public string? Postalcode { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("fax")]
    public string? Fax { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [InverseProperty("Supportrep")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [InverseProperty("ReportstoNavigation")]
    public virtual ICollection<Employee1> InverseReportstoNavigation { get; set; } = new List<Employee1>();

    [ForeignKey("Reportsto")]
    [InverseProperty("InverseReportstoNavigation")]
    public virtual Employee1? ReportstoNavigation { get; set; }
}
