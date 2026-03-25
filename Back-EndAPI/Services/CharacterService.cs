using Back_EndAPI.Data;
using Back_EndAPI.Entities;
using ClassLibrary.DTOs;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class CharacterService
{
    private readonly AppDbContext _context;

    public CharacterService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CharacterDTO>> GetAllAsync()
    {
        return await _context.Characters
            .Select(c => new CharacterDTO
            {
                Id = c.HeroId,
                Name = c.Name,
                Class = c.Class,
                Level = c.Level,
                Health = c.Health,
                Mana = c.Mana
            })
            .ToListAsync();
    }

    public async Task<CharacterDTO?> GetByIdAsync(Guid id)
    {
        return await _context.Characters
            .Where(c => c.HeroId == id)
            .Select(c => new CharacterDTO
            {
                Id = c.HeroId,
                Name = c.Name,
                Class = c.Class,
                Level = c.Level,
                Health = c.Health,
                Mana = c.Mana
            })
            .FirstOrDefaultAsync();
    }

    public async Task<CharacterDTO> CreateAsync(CharacterDTO dto)
    {
        // ---------------------------
        // Normalize
        // ---------------------------
        dto.Name = dto.Name.Trim();
        dto.Class = dto.Class.Trim();

        // ---------------------------
        // Extra structural rules
        // ---------------------------

        if (!Regex.IsMatch(dto.Name, @"^[a-zA-Z0-9]+$"))
            throw new ValidationException("Name must be alphanumeric.");

        var validClasses = new[] { "Warrior", "Mage", "Rogue", "Archer" };

        if (!validClasses.Any(c =>
            c.Equals(dto.Class, StringComparison.OrdinalIgnoreCase)))
        {
            throw new ValidationException("Invalid character class.");
        }

        dto.Class = validClasses
            .First(c => c.Equals(dto.Class,
                StringComparison.OrdinalIgnoreCase));

        // ---------------------------
        // Business rule
        // ---------------------------

        var exists = await _context.Characters
            .AnyAsync(c => c.Name.ToLower() == dto.Name.ToLower());

        if (exists)
            throw new ValidationException("Character name already exists.");

        if (dto.Class == "Rogue" && dto.Level > 40)
            throw new ValidationException("Rogues cannot exceed level 40.");

        // ---------------------------
        // Persist
        // ---------------------------

        var entity = new Character
        {
            HeroId = Guid.NewGuid(),
            Name = dto.Name,
            Class = dto.Class,
            Level = dto.Level,
            Health = dto.Health,
            Mana = dto.Mana,
            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified),
        };

        _context.Characters.Add(entity);
        await _context.SaveChangesAsync();

        dto.Id = entity.HeroId;

        return dto;
    }

    public async Task<bool> UpdateAsync(CharacterDTO dto)
    {
        var entity = await _context.Characters
            .FirstOrDefaultAsync(c => c.HeroId == dto.Id);

        if (entity == null)
            return false;

        dto.Name = dto.Name.Trim();
        dto.Class = dto.Class.Trim();

        if (!Regex.IsMatch(dto.Name, @"^[a-zA-Z0-9]+$"))
            throw new ValidationException("Name must be alphanumeric.");

        var validClasses = new[] { "Warrior", "Mage", "Rogue", "Archer" };

        if (!validClasses.Any(c =>
            c.Equals(dto.Class, StringComparison.OrdinalIgnoreCase)))
        {
            throw new ValidationException("Invalid character class.");
        }

        dto.Class = validClasses
            .First(c => c.Equals(dto.Class,
                StringComparison.OrdinalIgnoreCase));

        var duplicateExists = await _context.Characters
            .AnyAsync(c => c.Name.ToLower() == dto.Name.ToLower()
                        && c.HeroId != dto.Id);

        if (duplicateExists)
            throw new ValidationException("Character name already exists.");

        if (dto.Class == "Rogue" && dto.Level > 40)
            throw new ValidationException("Rogues cannot exceed level 40.");

        entity.Name = dto.Name;
        entity.Class = dto.Class;
        entity.Level = dto.Level;
        entity.Health = dto.Health;
        entity.Mana = dto.Mana;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _context.Characters
            .FirstOrDefaultAsync(c => c.HeroId == id);

        if (entity == null)
            return false;

        _context.Characters.Remove(entity);
        await _context.SaveChangesAsync();

        return true;
    }
}