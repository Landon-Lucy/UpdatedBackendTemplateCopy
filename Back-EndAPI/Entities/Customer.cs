using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("customer", Schema = "chinook")]
[Index("Supportrepid", Name = "idx_16956_ifk_customersupportrepid")]
public partial class Customer
{
    [Key]
    [Column("customerid")]
    public long Customerid { get; set; }

    [Column("firstname")]
    public string? Firstname { get; set; }

    [Column("lastname")]
    public string? Lastname { get; set; }

    [Column("company")]
    public string? Company { get; set; }

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

    [Column("supportrepid")]
    public long? Supportrepid { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    [ForeignKey("Supportrepid")]
    [InverseProperty("Customers")]
    public virtual Employee1? Supportrep { get; set; }
}
