using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ventas")]
public class Venta
{
    [Key]
    [Column("id_venta")]
    public int IdVenta { get; set; }

    [Column("fecha_venta")]
    public DateTime FechaVenta { get; set; } = DateTime.Now;

    [Column("id_cliente")]
    public int? IdCliente { get; set; }

    [ForeignKey("IdCliente")]
    public Cliente Cliente { get; set; }

    [Column("total_venta", TypeName = "numeric(10,2)")]
    public decimal TotalVenta { get; set; }

    [Required]
    [StringLength(30)]
    [Column("metodo_pago")]
    public string MetodoPago { get; set; }

    // Relación con el detalle de ventas
    public ICollection<DetalleVenta> DetalleVentas { get; set; }
}