using InventarioActivos.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarioActivos.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Activo> Activos => Set<Activo>();
}