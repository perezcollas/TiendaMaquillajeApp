using Microsoft.EntityFrameworkCore;
using TiendaMaquillajeApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaMaquillajeApp.Data
{
    public class ClienteService : IClienteService
    {
        private readonly TiendaDbContext _context;

        public ClienteService(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> ObtenerClientesAsync() =>
            await _context.Clientes.ToListAsync();

        public async Task AgregarClienteAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        // ← ESTE ES EL MÉTODO CORREGIDO
        public async Task EditarClienteAsync(Cliente cliente)
        {
            var clienteExistente = await _context.Clientes.FindAsync(cliente.IdCliente);
            if (clienteExistente != null)
            {
                clienteExistente.Nombre = cliente.Nombre;
                clienteExistente.Correo = cliente.Correo;
                clienteExistente.Telefono = cliente.Telefono;
                clienteExistente.Direccion = cliente.Direccion;

                await _context.SaveChangesAsync();
            }
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
