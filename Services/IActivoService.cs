using InventarioActivos.Dtos;

namespace InventarioActivos.Services;

public interface IActivoService
{
    Task<List<ActivoDto>> ObtenerTodosAsync();
    Task<ActivoDto?> ObtenerPorIdAsync(int id);
    Task<ActivoDto> CrearAsync(GuardarActivoDto dto);
    Task<bool> ActualizarAsync(int id, GuardarActivoDto dto);
    Task<bool> EliminarAsync(int id);
}