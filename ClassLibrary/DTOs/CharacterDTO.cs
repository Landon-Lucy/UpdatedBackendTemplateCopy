using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.DTOs;

public class CharacterDTO
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = "";

    [Required]
    public string Class { get; set; } = "";

    [Range(1, 50)]
    public int Level { get; set; }

    [Range(1, int.MaxValue)]
    public int Health { get; set; }

    [Range(0, int.MaxValue)]
    public int Mana { get; set; }
}
