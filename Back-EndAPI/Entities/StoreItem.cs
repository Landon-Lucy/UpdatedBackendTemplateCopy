using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("store_item")]
public partial class StoreItem
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("itemname")]
    [StringLength(30)]
    public string? Itemname { get; set; }

    [Column("shelfprice", TypeName = "money")]
    public decimal? Shelfprice { get; set; }

    [InverseProperty("Item")]
    public virtual ICollection<StoreCheckoutItem> StoreCheckoutItems { get; set; } = new List<StoreCheckoutItem>();

    [InverseProperty("Item")]
    public virtual ICollection<StoreOrderItem> StoreOrderItems { get; set; } = new List<StoreOrderItem>();
}
