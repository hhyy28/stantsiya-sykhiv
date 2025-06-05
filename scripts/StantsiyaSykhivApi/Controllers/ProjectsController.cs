using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StantsiyaSykhivApi.Data;
using StantsiyaSykhivApi.Data.Models.Entities;

namespace StantsiyaSykhivApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProjectsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProjectsController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetAll() => await _context.Projects.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> Get(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        return project is null ? NotFound() : Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = project.Id }, project);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Project updated)
    {
        if (id != updated.Id) return BadRequest();
        _context.Entry(updated).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.Projects.FindAsync(id);
        if (item is null) return NotFound();
        _context.Projects.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
