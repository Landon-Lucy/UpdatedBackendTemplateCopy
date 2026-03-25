using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("audit_log", Schema = "f25election")]
public partial class AuditLog
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("election_id")]
    public int ElectionId { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("action_type")]
    [StringLength(50)]
    public string ActionType { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("is_public")]
    public bool? IsPublic { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("ElectionId")]
    [InverseProperty("AuditLogs")]
    public virtual Election Election { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("AuditLogs")]
    public virtual Person? User { get; set; }
}
