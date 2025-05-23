using Microsoft.EntityFrameworkCore;
using TiendaMaquillajeApp.Data;

namespace TiendaMaquillajeApp.Data
{
    public class TiendaDbContext : DbContext
    {
        public TiendaDbContext(DbContextOptions<TiendaDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
