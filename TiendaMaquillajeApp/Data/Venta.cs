using System.ComponentModel.DataAnnotations;

namespace TiendaMaquillajeApp.Data
{
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        public DateTime FechaVenta { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal Total { get; set; }

        public Cliente Cliente { get; set; }
        public Producto Producto { get; set; }
    }
}
