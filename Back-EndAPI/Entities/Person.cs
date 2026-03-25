using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("person", Schema = "f25election")]
public partial class Person
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Column("birth_date")]
    public DateOnly BirthDate { get; set; }

    [Column("email")]
    [StringLength(100)]
    public string? Email { get; set; }

    [Column("zipcode")]
    [StringLength(5)]
    public string? Zipcode { get; set; }

    [InverseProperty("PostedByUser")]
    public virtual ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();

    [InverseProperty("User")]
    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    [InverseProperty("Person")]
    public virtual ICollection<PersonRegistered> PersonRegistereds { get; set; } = new List<PersonRegistered>();

    [InverseProperty("Observer")]
    public virtual ICollection<RoundGroup> RoundGroups { get; set; } = new List<RoundGroup>();

    [InverseProperty("InvitedByUser")]
    public virtual ICollection<UserElectionRole> UserElectionRoleInvitedByUsers { get; set; } = new List<UserElectionRole>();

    [InverseProperty("User")]
    public virtual ICollection<UserElectionRole> UserElectionRoleUsers { get; set; } = new List<UserElectionRole>();
}
