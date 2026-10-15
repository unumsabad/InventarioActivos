using System.ComponentModel.DataAnnotations;

namespace InventarioActivos.Dtos;

public class ActivoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string Serial { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
}

public class GuardarActivoDto
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El tipo es obligatorio")]
    public string Tipo { get; set; } = string.Empty;

    [Required(ErrorMessage = "El serial es obligatorio")]
    public string Serial { get; set; } = string.Empty;

    public string Estado { get; set; } = "Disponible";
}