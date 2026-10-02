using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("inventario")]
public class Inventario
{
    [Key]
    [Column("id_item")]
    public int IdItem { get; set; }

    [Required]
    [StringLength(100)]
    [Column("nombre")]
    public string Nombre { get; set; }

    [Column("descripcion")]
    public string Descripcion { get; set; }

    [Required]
    [StringLength(20)]
    [Column("unidad_medida")]
    public string UnidadMedida { get; set; }

    [Column("stock_actual", TypeName = "numeric(10,2)")]
    public decimal StockActual { get; set; } = 0.00m;

    [Column("stock_minimo", TypeName = "numeric(10,2)")]
    public decimal StockMinimo { get; set; } = 5.00m;

    [Column("costo_unitario", TypeName = "numeric(10,2)")]
    public decimal CostoUnitario { get; set; }

    [Column("id_proveedor")]
    public int? IdProveedor { get; set; }

    [ForeignKey("IdProveedor")]
    public Proveedor Proveedor { get; set; }

    // Relación con recetas
    public ICollection<RecetaProducto> RecetaProductos { get; set; }
}