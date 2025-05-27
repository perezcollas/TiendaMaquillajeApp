using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaMaquillajeApp.Data
{
    public interface IVentaService
    {
        Task<List<Venta>> ObtenerVentasAsync();
        Task<Venta> ObtenerVentaPorIdAsync(int idVenta);
        Task AgregarVentaAsync(Venta venta);
        Task EditarVentaAsync(Venta venta);        // ← Aquí definimos EditarVentaAsync
        Task EliminarVentaAsync(int idVenta);
        Task<List<Venta>> ObtenerVentasPorClienteAsync(int idCliente);
        Task<List<Venta>> ObtenerVentasPorProductoAsync(int idProducto);
        Task<List<Venta>> ObtenerVentasPorFechaAsync(DateTime fecha);
    }
}
