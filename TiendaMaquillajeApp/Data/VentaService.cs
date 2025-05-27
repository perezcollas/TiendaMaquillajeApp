using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TiendaMaquillajeApp.Data
{
    public class VentaService : IVentaService
    {
        private readonly TiendaDbContext _context;

        public VentaService(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Venta>> ObtenerVentasAsync()
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Producto)
                .ToListAsync();
        }

        public async Task<Venta> ObtenerVentaPorIdAsync(int idVenta)
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Producto)
                .FirstOrDefaultAsync(v => v.IdVenta == idVenta);
        }

        public async Task AgregarVentaAsync(Venta venta)
        {
            _context.Ventas.Add(venta);
            // (Opcional) Ajustar stock del producto:
            var producto = await _context.Productos.FindAsync(venta.IdProducto);
            if (producto != null)
            {
                producto.Stock -= venta.Cantidad;
                _context.Productos.Update(producto);
            }
            await _context.SaveChangesAsync();
        }

        public async Task EditarVentaAsync(Venta venta)   // ← Aquí implementamos EditarVentaAsync
        {
            var ventaExistente = await _context.Ventas.FindAsync(venta.IdVenta);
            if (ventaExistente != null)
            {
                ventaExistente.IdCliente = venta.IdCliente;
                ventaExistente.IdProducto = venta.IdProducto;
                ventaExistente.FechaVenta = venta.FechaVenta;
                ventaExistente.Cantidad = venta.Cantidad;
                ventaExistente.Total = venta.Total;

                _context.Ventas.Update(ventaExistente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EliminarVentaAsync(int idVenta)
        {
            var venta = await _context.Ventas.FindAsync(idVenta);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Venta>> ObtenerVentasPorClienteAsync(int idCliente)
        {
            return await _context.Ventas
                .Where(v => v.IdCliente == idCliente)
                .Include(v => v.Producto)
                .ToListAsync();
        }

        public async Task<List<Venta>> ObtenerVentasPorProductoAsync(int idProducto)
        {
            return await _context.Ventas
                .Where(v => v.IdProducto == idProducto)
                .Include(v => v.Cliente)
                .ToListAsync();
        }

        public async Task<List<Venta>> ObtenerVentasPorFechaAsync(DateTime fecha)
        {
            return await _context.Ventas
                .Where(v => v.FechaVenta.Date == fecha.Date)
                .Include(v => v.Cliente)
                .Include(v => v.Producto)
                .ToListAsync();
        }
    }
}
