using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("invoiceline", Schema = "chinook")]
[Index("Invoiceid", Name = "idx_16980_ifk_invoicelineinvoiceid")]
[Index("Trackid", Name = "idx_16980_ifk_invoicelinetrackid")]
public partial class Invoiceline
{
    [Key]
    [Column("invoicelineid")]
    public long Invoicelineid { get; set; }

    [Column("invoiceid")]
    public long? Invoiceid { get; set; }

    [Column("trackid")]
    public long? Trackid { get; set; }

    [Column("unitprice")]
    public decimal? Unitprice { get; set; }

    [Column("quantity")]
    public long? Quantity { get; set; }

    [ForeignKey("Invoiceid")]
    [InverseProperty("Invoicelines")]
    public virtual Invoice? Invoice { get; set; }

    [ForeignKey("Trackid")]
    [InverseProperty("Invoicelines")]
    public virtual Track? Track { get; set; }
}
