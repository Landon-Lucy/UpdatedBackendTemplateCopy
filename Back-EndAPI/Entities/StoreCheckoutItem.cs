using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("store_checkout_item")]
public partial class StoreCheckoutItem
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("itemid")]
    public int? Itemid { get; set; }

    [Column("checkoutid")]
    public int? Checkoutid { get; set; }

    [Column("quantity")]
    public int? Quantity { get; set; }

    [Column("actualprice", TypeName = "money")]
    public decimal? Actualprice { get; set; }

    [ForeignKey("Checkoutid")]
    [InverseProperty("StoreCheckoutItems")]
    public virtual StoreCheckout? Checkout { get; set; }

    [ForeignKey("Itemid")]
    [InverseProperty("StoreCheckoutItems")]
    public virtual StoreItem? Item { get; set; }
}
