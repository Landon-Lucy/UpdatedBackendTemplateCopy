using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("vote_submission", Schema = "f25election")]
[Index("RoundGroupId", "VoterPersonRegId", Name = "vote_submission_voter_idx")]
public partial class VoteSubmission
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("round_group_id")]
    public int RoundGroupId { get; set; }

    [Column("voter_person_reg_id")]
    public int VoterPersonRegId { get; set; }

    [Column("submitted_at", TypeName = "timestamp without time zone")]
    public DateTime SubmittedAt { get; set; }

    [ForeignKey("RoundGroupId")]
    [InverseProperty("VoteSubmissions")]
    public virtual RoundGroup RoundGroup { get; set; } = null!;

    [InverseProperty("Submission")]
    public virtual ICollection<VoteRank> VoteRanks { get; set; } = new List<VoteRank>();

    [ForeignKey("VoterPersonRegId")]
    [InverseProperty("VoteSubmissions")]
    public virtual PersonRegistered VoterPersonReg { get; set; } = null!;
}
