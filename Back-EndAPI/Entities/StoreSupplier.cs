using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("store_supplier")]
public partial class StoreSupplier
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("suppliername")]
    [StringLength(30)]
    public string? Suppliername { get; set; }

    [InverseProperty("Supplier")]
    public virtual ICollection<StoreOrder> StoreOrders { get; set; } = new List<StoreOrder>();
}
