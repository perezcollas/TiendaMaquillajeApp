using Microsoft.EntityFrameworkCore;
using TiendaMaquillajeApp.Data;


namespace TiendaMaquillajeApp.Data
{
    public class ClienteService : IClienteService
    {
        private readonly TiendaDbContext _context;

        public ClienteService(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> ObtenerClientesAsync() => await _context.Clientes.ToListAsync();

        public async Task AgregarClienteAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task EditarClienteAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarClienteAsync(int idCliente)
        {
            var cliente = await _context.Clientes.FindAsync(idCliente);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }

}

