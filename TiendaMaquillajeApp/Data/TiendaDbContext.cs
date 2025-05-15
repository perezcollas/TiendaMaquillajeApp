using Microsoft.EntityFrameworkCore;

namespace TiendaMaquillajeApp.Data
{
    public class TiendaDbContext : DbContext
    {
        public TiendaDbContext(DbContextOptions<TiendaDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; } // Asegúrate de tener la clase Producto creada
    }
}
