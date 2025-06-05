using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StantsiyaSykhivApi.Data;
using StantsiyaSykhivApi.Data.Models.Entities;

namespace StantsiyaSykhivApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ColumnsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ColumnsController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IEnumerable<Column>> GetAll() => await _context.Columns.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Column>> Get(int id)
    {
        var item = await _context.Columns.FindAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Column column)
    {
        _context.Columns.Add(column);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = column.Id }, column);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Column updated)
    {
        if (id != updated.Id) return BadRequest();
        _context.Entry(updated).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.Columns.FindAsync(id);
        if (item is null) return NotFound();
        _context.Columns.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
