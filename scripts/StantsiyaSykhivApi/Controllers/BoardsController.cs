using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StantsiyaSykhivApi.Data;
using StantsiyaSykhivApi.Data.Models.Entities;

namespace StantsiyaSykhivApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BoardsController : ControllerBase
{
    private readonly AppDbContext _context;

    public BoardsController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IEnumerable<Board>> GetAll() => await _context.Boards.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Board>> Get(int id)
    {
        var item = await _context.Boards.FindAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Board board)
    {
        _context.Boards.Add(board);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = board.Id }, board);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Board updated)
    {
        if (id != updated.Id) return BadRequest();
        _context.Entry(updated).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.Boards.FindAsync(id);
        if (item is null) return NotFound();
        _context.Boards.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
