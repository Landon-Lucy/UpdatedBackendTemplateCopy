using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Keyless]
[Table("person_registered_round_group_test", Schema = "f25election")]
public partial class PersonRegisteredRoundGroupTest
{
    [Column("id")]
    public int Id { get; set; }

    [Column("person_reg_id")]
    public int? PersonRegId { get; set; }

    [Column("round_group_id")]
    public int? RoundGroupId { get; set; }

    [Column("person_vote_result")]
    public int? PersonVoteResult { get; set; }
}
