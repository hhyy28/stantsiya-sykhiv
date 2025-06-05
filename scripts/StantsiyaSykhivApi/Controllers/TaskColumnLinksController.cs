using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StantsiyaSykhivApi.Data;
using StantsiyaSykhivApi.Data.Models.Entities;

namespace StantsiyaSykhivApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TaskColumnLinksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TaskColumnLinksController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IEnumerable<TaskColumnLink>> GetAll() => await _context.TaskColumnLinks.ToListAsync();

    [HttpPost]
    public async Task<IActionResult> Create(TaskColumnLink link)
    {
        _context.TaskColumnLinks.Add(link);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { task_id = link.TaskId, column_id = link.ColumnId }, link);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int taskId, int columnId)
    {
        var link = await _context.TaskColumnLinks.FindAsync(taskId, columnId);
        if (link is null) return NotFound();
        _context.TaskColumnLinks.Remove(link);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
