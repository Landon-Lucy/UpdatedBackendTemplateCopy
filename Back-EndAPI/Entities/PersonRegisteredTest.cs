using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;

[Keyless]
[Table("person_registered_test", Schema = "f25election")]
public partial class PersonRegisteredTest
{
    [Column("id")]
    public int Id { get; set; }

    [Column("person_id")]
    public int? PersonId { get; set; }

    [Column("election_id")]
    public int? ElectionId { get; set; }

    [Column("registered", TypeName = "timestamp without time zone")]
    public DateTime? Registered { get; set; }
}
