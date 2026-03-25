using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("store_employee")]
public partial class StoreEmployee
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("employeename")]
    [StringLength(30)]
    public string? Employeename { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<StoreCheckout> StoreCheckouts { get; set; } = new List<StoreCheckout>();
}
