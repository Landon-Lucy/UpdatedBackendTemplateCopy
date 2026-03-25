using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Keyless]
[Table("election_test", Schema = "f25election")]
public partial class ElectionTest
{
    [Column("id")]
    public int Id { get; set; }

    [Column("ideal_group_size")]
    public int? IdealGroupSize { get; set; }

    [Column("num_people_advancing_each_round")]
    public int? NumPeopleAdvancingEachRound { get; set; }

    [Column("num_final_winners")]
    public int? NumFinalWinners { get; set; }

    [Column("election_name")]
    [StringLength(100)]
    public string? ElectionName { get; set; }
}
