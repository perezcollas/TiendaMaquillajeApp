using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaMaquillajeApp.Data;

namespace TiendaMaquillajeApp.Data
{
    public interface IClienteService
    {
        Task<List<Cliente>> ObtenerClientesAsync();
        Task AgregarClienteAsync(Cliente cliente);
        Task EditarClienteAsync(Cliente cliente);
        Task EliminarClienteAsync(int idCliente);
    }
}
