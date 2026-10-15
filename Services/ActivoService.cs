using InventarioActivos.Data;
using InventarioActivos.Dtos;
using InventarioActivos.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarioActivos.Services;

public class ActivoService : IActivoService
{
    private readonly AppDbContext _context;

    public ActivoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ActivoDto>> ObtenerTodosAsync()
    {
        var activos = await _context.Activos.AsNoTracking().ToListAsync();
        return activos.Select(ADto).ToList();
    }

    public async Task<ActivoDto?> ObtenerPorIdAsync(int id)
    {
        var activo = await _context.Activos.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        return activo is null ? null : ADto(activo);
    }

    public async Task<ActivoDto> CrearAsync(GuardarActivoDto dto)
    {
        var activo = new Activo
        {
            Nombre = dto.Nombre,
            Tipo = dto.Tipo,
            Serial = dto.Serial,
            Estado = dto.Estado
        };

        _context.Activos.Add(activo);
        await _context.SaveChangesAsync();
        return ADto(activo);
    }

    public async Task<bool> ActualizarAsync(int id, GuardarActivoDto dto)
    {
        var activo = await _context.Activos.FindAsync(id);
        if (activo is null) return false;

        activo.Nombre = dto.Nombre;
        activo.Tipo = dto.Tipo;
        activo.Serial = dto.Serial;
        activo.Estado = dto.Estado;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var activo = await _context.Activos.FindAsync(id);
        if (activo is null) return false;

        _context.Activos.Remove(activo);
        await _context.SaveChangesAsync();
        return true;
    }

    private static ActivoDto ADto(Activo activo) => new()
    {
        Id = activo.Id,
        Nombre = activo.Nombre,
        Tipo = activo.Tipo,
        Serial = activo.Serial,
        Estado = activo.Estado
    };
}