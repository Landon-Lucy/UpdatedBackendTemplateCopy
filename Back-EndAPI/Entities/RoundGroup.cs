using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("round_group", Schema = "f25election")]
public partial class RoundGroup
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("election_id")]
    public int ElectionId { get; set; }

    [Column("round")]
    public int Round { get; set; }

    [Column("meeting_place")]
    [StringLength(2000)]
    public string? MeetingPlace { get; set; }

    [Column("meeting_datetime", TypeName = "timestamp without time zone")]
    public DateTime? MeetingDatetime { get; set; }

    [Column("observer_id")]
    public int? ObserverId { get; set; }

    [ForeignKey("ElectionId")]
    [InverseProperty("RoundGroups")]
    public virtual Election Election { get; set; } = null!;

    [ForeignKey("ObserverId")]
    [InverseProperty("RoundGroups")]
    public virtual Person? Observer { get; set; }

    [InverseProperty("RoundGroup")]
    public virtual ICollection<PersonRegisteredRoundGroup> PersonRegisteredRoundGroups { get; set; } = new List<PersonRegisteredRoundGroup>();

    [InverseProperty("RoundGroup")]
    public virtual ICollection<VoteSubmission> VoteSubmissions { get; set; } = new List<VoteSubmission>();
}
