using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Keyless]
[Table("round_group_test", Schema = "f25election")]
public partial class RoundGroupTest
{
    [Column("id")]
    public int Id { get; set; }

    [Column("election_id")]
    public int? ElectionId { get; set; }

    [Column("round")]
    public int? Round { get; set; }

    [Column("meeting_place")]
    [StringLength(2000)]
    public string? MeetingPlace { get; set; }

    [Column("meeting_datetime", TypeName = "timestamp without time zone")]
    public DateTime? MeetingDatetime { get; set; }

    [Column("observer_id")]
    public int? ObserverId { get; set; }
}
