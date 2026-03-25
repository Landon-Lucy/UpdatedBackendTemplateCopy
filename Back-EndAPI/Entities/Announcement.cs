using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("announcement", Schema = "f25election")]
public partial class Announcement
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("election_id")]
    public int ElectionId { get; set; }

    [Column("posted_by_user_id")]
    public int PostedByUserId { get; set; }

    [Column("content")]
    public string Content { get; set; } = null!;

    [Column("visibility")]
    [StringLength(20)]
    public string? Visibility { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("ElectionId")]
    [InverseProperty("Announcements")]
    public virtual Election Election { get; set; } = null!;

    [ForeignKey("PostedByUserId")]
    [InverseProperty("Announcements")]
    public virtual Person PostedByUser { get; set; } = null!;
}
