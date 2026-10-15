using InventarioActivos.Data;
using InventarioActivos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioActivos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ActivosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Activo>>> GetAll()
    {
        return await _context.Activos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activo>> GetById(int id)
    {
        var activo = await _context.Activos.FindAsync(id);
        if (activo is null) return NotFound();
        return activo;
    }

    [HttpPost]
    public async Task<ActionResult<Activo>> Create(Activo activo)
    {
        _context.Activos.Add(activo);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = activo.Id }, activo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Activo activo)
    {
        if (id != activo.Id) return BadRequest();
        _context.Entry(activo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var activo = await _context.Activos.FindAsync(id);
        if (activo is null) return NotFound();
        _context.Activos.Remove(activo);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}