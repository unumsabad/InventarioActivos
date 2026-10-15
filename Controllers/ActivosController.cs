using InventarioActivos.Dtos;
using InventarioActivos.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioActivos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivosController : ControllerBase
{
    private readonly IActivoService _service;

    public ActivosController(IActivoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<ActivoDto>>> GetAll()
    {
        return await _service.ObtenerTodosAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ActivoDto>> GetById(int id)
    {
        var activo = await _service.ObtenerPorIdAsync(id);
        if (activo is null) return NotFound();
        return activo;
    }

    [HttpPost]
    public async Task<ActionResult<ActivoDto>> Create(GuardarActivoDto dto)
    {
        var creado = await _service.CrearAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, GuardarActivoDto dto)
    {
        var actualizado = await _service.ActualizarAsync(id, dto);
        if (!actualizado) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _service.EliminarAsync(id);
        if (!eliminado) return NotFound();
        return NoContent();
    }
}