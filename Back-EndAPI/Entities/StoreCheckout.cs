using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("store_checkout")]
public partial class StoreCheckout
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("customerid")]
    public int? Customerid { get; set; }

    [Column("employeeid")]
    public int? Employeeid { get; set; }

    [Column("checkoutdate")]
    public DateOnly? Checkoutdate { get; set; }

    [Column("taxamount", TypeName = "money")]
    public decimal? Taxamount { get; set; }

    [ForeignKey("Customerid")]
    [InverseProperty("StoreCheckouts")]
    public virtual StoreCustomer? Customer { get; set; }

    [ForeignKey("Employeeid")]
    [InverseProperty("StoreCheckouts")]
    public virtual StoreEmployee? Employee { get; set; }

    [InverseProperty("Checkout")]
    public virtual ICollection<StoreCheckoutItem> StoreCheckoutItems { get; set; } = new List<StoreCheckoutItem>();
}
