using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("detalle_ventas")]
public class DetalleVenta
{
    [Key]
    [Column("id_detalle")]
    public int IdDetalle { get; set; }

    [Column("id_venta")]
    public int IdVenta { get; set; }

    [ForeignKey("IdVenta")]
    public Venta Venta { get; set; }

    [Column("id_producto")]
    public int IdProducto { get; set; }

    [ForeignKey("IdProducto")]
    public Producto Producto { get; set; }

    [Column("cantidad")]
    public int Cantidad { get; set; }

    [Column("precio_unitario", TypeName = "numeric(10,2)")]
    public decimal PrecioUnitario { get; set; }

    [Column("subtotal", TypeName = "numeric(10,2)")]
    public decimal Subtotal { get; set; }
}