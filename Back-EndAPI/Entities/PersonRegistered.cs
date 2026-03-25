using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Table("person_registered", Schema = "f25election")]
[Index("PersonId", "ElectionId", Name = "person_registered_person_id_idx", IsUnique = true)]
public partial class PersonRegistered
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("person_id")]
    public int PersonId { get; set; }

    [Column("election_id")]
    public int ElectionId { get; set; }

    [Column("registered", TypeName = "timestamp without time zone")]
    public DateTime Registered { get; set; }

    [ForeignKey("ElectionId")]
    [InverseProperty("PersonRegistereds")]
    public virtual Election Election { get; set; } = null!;

    [ForeignKey("PersonId")]
    [InverseProperty("PersonRegistereds")]
    public virtual Person Person { get; set; } = null!;

    [InverseProperty("PersonReg")]
    public virtual ICollection<PersonRegisteredRoundGroup> PersonRegisteredRoundGroups { get; set; } = new List<PersonRegisteredRoundGroup>();

    [InverseProperty("VoterPersonReg")]
    public virtual ICollection<VoteSubmission> VoteSubmissions { get; set; } = new List<VoteSubmission>();
}
