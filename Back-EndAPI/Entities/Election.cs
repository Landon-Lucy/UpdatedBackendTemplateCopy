using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("election", Schema = "f25election")]
public partial class Election
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("ideal_group_size")]
    public int IdealGroupSize { get; set; }

    [Column("num_people_advancing_each_round")]
    public int NumPeopleAdvancingEachRound { get; set; }

    [Column("num_final_winners")]
    public int NumFinalWinners { get; set; }

    [Column("election_name")]
    [StringLength(100)]
    public string? ElectionName { get; set; }

    [InverseProperty("Election")]
    public virtual ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();

    [InverseProperty("Election")]
    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    [InverseProperty("Election")]
    public virtual ICollection<PersonRegistered> PersonRegistereds { get; set; } = new List<PersonRegistered>();

    [InverseProperty("Election")]
    public virtual ICollection<RoundGroup> RoundGroups { get; set; } = new List<RoundGroup>();

    [InverseProperty("Election")]
    public virtual ICollection<UserElectionRole> UserElectionRoles { get; set; } = new List<UserElectionRole>();
}
