using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("vote_rank", Schema = "f25election")]
[Index("SubmissionId", "TargetPrrgId", Name = "vote_rank_unique_target_per_submission", IsUnique = true)]
public partial class VoteRank
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("submission_id")]
    public int SubmissionId { get; set; }

    [Column("target_prrg_id")]
    public int TargetPrrgId { get; set; }

    [Column("rank")]
    public int Rank { get; set; }

    [ForeignKey("SubmissionId")]
    [InverseProperty("VoteRanks")]
    public virtual VoteSubmission Submission { get; set; } = null!;

    [ForeignKey("TargetPrrgId")]
    [InverseProperty("VoteRanks")]
    public virtual PersonRegisteredRoundGroup TargetPrrg { get; set; } = null!;
}
