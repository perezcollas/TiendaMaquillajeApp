using System.ComponentModel.DataAnnotations;

public class Producto
{
    [Key]
    public int IdProducto { get; set; }

    [Required, StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string Categoria { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string Marca { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Precio { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}
