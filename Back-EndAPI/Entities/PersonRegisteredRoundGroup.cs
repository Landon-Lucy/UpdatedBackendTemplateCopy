using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("person_registered_round_group", Schema = "f25election")]
public partial class PersonRegisteredRoundGroup
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("person_reg_id")]
    public int PersonRegId { get; set; }

    [Column("round_group_id")]
    public int RoundGroupId { get; set; }

    [Column("person_vote_result")]
    public int? PersonVoteResult { get; set; }

    [ForeignKey("PersonRegId")]
    [InverseProperty("PersonRegisteredRoundGroups")]
    public virtual PersonRegistered PersonReg { get; set; } = null!;

    [ForeignKey("RoundGroupId")]
    [InverseProperty("PersonRegisteredRoundGroups")]
    public virtual RoundGroup RoundGroup { get; set; } = null!;

    [InverseProperty("TargetPrrg")]
    public virtual ICollection<VoteRank> VoteRanks { get; set; } = new List<VoteRank>();
}
