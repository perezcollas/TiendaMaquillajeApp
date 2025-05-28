using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaMaquillajeApp.Data
{
    public interface IProductoService
    {
        Task<List<Producto>> ObtenerProductosAsync();
        Task ActualizarProductoAsync(Producto producto);
        Task EliminarProductoAsync(int id);

    }
}