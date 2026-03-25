using ClassLibrary.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly CharacterService _service;

    public CharactersController(CharacterService service)
    {
        _service = service;
    }

    // ============================================================
    // GET ALL
    // ============================================================
    [HttpGet]
    public async Task<ActionResult<List<CharacterDTO>>> GetAll()
    {
        try
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "An error occurred while retrieving characters.",
                detail = ex.Message
            });
        }
    }

    // ============================================================
    // GET BY ID
    // ============================================================
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest(Error("Invalid Id."));

        var character = await _service.GetByIdAsync(id);

        if (character == null)
            return NotFound(Error("Character not found."));
        //
        return Ok(character);
    }

    // ============================================================
    // CREATE
    // ============================================================
    [HttpPost]
    //[Authorize(Roles = "CoolGuy, Admin")]//has Create role
    //[Authorize(Policy = "Create")]//permission instead of role
    [Authorize(Policy = "character.create")]
    public async Task<IActionResult> Create(CharacterDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Client cannot set Id during creation
        if (dto.Id != Guid.Empty)
            return BadRequest(Error("Id cannot be set during creation."));

        try
        {
            var created = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                created);
        }
        catch (ValidationException ex)
        {
            return BadRequest(Error(ex.Message));
        }
    }

    // ============================================================
    // UPDATE
    // ============================================================
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, CharacterDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id == Guid.Empty)
            return BadRequest(Error("Invalid Id."));

        if (dto.Id != id)
            return BadRequest(Error("Route Id must match body Id."));

        try
        {
            var updated = await _service.UpdateAsync(dto);

            if (!updated)
                return NotFound(Error("Character not found."));

            return NoContent();
        }
        catch (ValidationException ex)
        {
            return BadRequest(Error(ex.Message));
        }
    }

    // ============================================================
    // DELETE
    // ============================================================
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest(Error("Invalid Id."));

        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound(Error("Character not found."));

        return NoContent();
    }

    private object Error(string message) => new
    {
        error = message,
        timestamp = DateTime.UtcNow
    };
}