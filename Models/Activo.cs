namespace InventarioActivos.Models;

public class Activo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string Serial { get; set; } = string.Empty;
    public string Estado { get; set; } = "Disponible";
}