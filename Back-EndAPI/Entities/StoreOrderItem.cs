using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("store_order_item")]
public partial class StoreOrderItem
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("itemid")]
    public int? Itemid { get; set; }

    [Column("orderid")]
    public int? Orderid { get; set; }

    [Column("quantity")]
    public int? Quantity { get; set; }

    [Column("actualprice", TypeName = "money")]
    public decimal? Actualprice { get; set; }

    [ForeignKey("Itemid")]
    [InverseProperty("StoreOrderItems")]
    public virtual StoreItem? Item { get; set; }

    [ForeignKey("Orderid")]
    [InverseProperty("StoreOrderItems")]
    public virtual StoreOrder? Order { get; set; }
}
