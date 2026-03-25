using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Entities
{
    //
    // ENTITY ROLE
    // ------------
    // Entities represent DATABASE TABLES.
    //
    // Entities:
    // - Match the database schema exactly
    // - Use attributes for column mapping
    // - Are NOT safe to return to the frontend
    //
    // Changing this class usually means changing the database.
    //

    [Table("character")] // Maps this class to the "character" table
    public class EXCharacter
    {
        [Key] // Primary key
        [Column("hero_id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("class")]
        public string Class { get; set; } = string.Empty;

        [Column("level")]
        public int Level { get; set; }

        [Column("health")]
        public int Health { get; set; }

        [Column("mana")]
        public int Mana { get; set; }

        // Exists in the database but NOT exposed to the client
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
