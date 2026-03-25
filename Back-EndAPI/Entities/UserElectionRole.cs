using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("user_election_role", Schema = "f25election")]
[Index("UserId", "ElectionId", Name = "user_election_role_user_id_election_id_key", IsUnique = true)]
public partial class UserElectionRole
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("election_id")]
    public int ElectionId { get; set; }

    [Column("role")]
    [StringLength(20)]
    public string Role { get; set; } = null!;

    [Column("invited_by_user_id")]
    public int? InvitedByUserId { get; set; }

    [Column("joined_at", TypeName = "timestamp without time zone")]
    public DateTime? JoinedAt { get; set; }

    [Column("status")]
    [StringLength(20)]
    public string? Status { get; set; }

    [ForeignKey("ElectionId")]
    [InverseProperty("UserElectionRoles")]
    public virtual Election Election { get; set; } = null!;

    [ForeignKey("InvitedByUserId")]
    [InverseProperty("UserElectionRoleInvitedByUsers")]
    public virtual Person? InvitedByUser { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserElectionRoleUsers")]
    public virtual Person User { get; set; } = null!;
}
