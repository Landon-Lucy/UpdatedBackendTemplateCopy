using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("store_order")]
public partial class StoreOrder
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("supplierid")]
    public int? Supplierid { get; set; }

    [Column("datepurchased")]
    public DateOnly? Datepurchased { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<StoreOrderItem> StoreOrderItems { get; set; } = new List<StoreOrderItem>();

    [ForeignKey("Supplierid")]
    [InverseProperty("StoreOrders")]
    public virtual StoreSupplier? Supplier { get; set; }
}
