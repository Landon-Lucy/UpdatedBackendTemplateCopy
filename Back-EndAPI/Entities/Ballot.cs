using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("ballot", Schema = "f25election")]
public partial class Ballot
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("voter_id")]
    public int VoterId { get; set; }

    [Column("candidate_id")]
    public int CandidateId { get; set; }

    [Column("rank")]
    public int Rank { get; set; }
}
