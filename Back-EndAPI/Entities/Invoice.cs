using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("invoice", Schema = "chinook")]
[Index("Customerid", Name = "idx_16974_ifk_invoicecustomerid")]
public partial class Invoice
{
    [Key]
    [Column("invoiceid")]
    public long Invoiceid { get; set; }

    [Column("customerid")]
    public long? Customerid { get; set; }

    [Column("invoicedate")]
    public DateTime? Invoicedate { get; set; }

    [Column("billingaddress")]
    public string? Billingaddress { get; set; }

    [Column("billingcity")]
    public string? Billingcity { get; set; }

    [Column("billingstate")]
    public string? Billingstate { get; set; }

    [Column("billingcountry")]
    public string? Billingcountry { get; set; }

    [Column("billingpostalcode")]
    public string? Billingpostalcode { get; set; }

    [Column("total")]
    public decimal? Total { get; set; }

    [ForeignKey("Customerid")]
    [InverseProperty("Invoices")]
    public virtual Customer? Customer { get; set; }

    [InverseProperty("Invoice")]
    public virtual ICollection<Invoiceline> Invoicelines { get; set; } = new List<Invoiceline>();
}
