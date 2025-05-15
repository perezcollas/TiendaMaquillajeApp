using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaMaquillajeApp.Data
{
    public class ProductoService : IProductoService
    {
        private readonly TiendaDbContext _context;

        public ProductoService(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task ActualizarProductoAsync(Producto producto)
        {
            var productoExistente = await _context.Productos.FindAsync(producto.IdProducto);
            if (productoExistente != null)
            {
                productoExistente.Nombre = producto.Nombre;
                productoExistente.Precio = producto.Precio;
                productoExistente.Stock = producto.Stock;

                await _context.SaveChangesAsync();
            }
        }

        public async Task EliminarProductoAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
