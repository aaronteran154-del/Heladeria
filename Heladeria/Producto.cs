using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("productos")]
public class Producto
{
    [Key]
    [Column("id_producto")]
    public int IdProducto { get; set; }

    [Required]
    [StringLength(100)]
    [Column("nombre")]
    public string Nombre { get; set; }

    [Required]
    [StringLength(50)]
    [Column("categoria")]
    public string Categoria { get; set; }

    [Column("precio_venta", TypeName = "numeric(10,2)")]
    public decimal PrecioVenta { get; set; }

    [Column("disponible")]
    public bool Disponible { get; set; } = true;

    // Relaciones
    public ICollection<RecetaProducto> RecetaProductos { get; set; }
    public ICollection<DetalleVenta> DetalleVentas { get; set; }
}