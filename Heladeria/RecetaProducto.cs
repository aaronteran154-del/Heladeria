using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("receta_productos")]
public class RecetaProducto
{
    [Key]
    [Column("id_receta")]
    public int IdReceta { get; set; }

    [Column("id_producto")]
    public int IdProducto { get; set; }

    [ForeignKey("IdProducto")]
    public Producto Producto { get; set; }

    [Column("id_item")]
    public int IdItem { get; set; }

    [ForeignKey("IdItem")]
    public Inventario Inventario { get; set; }

    [Column("cantidad_requerida", TypeName = "numeric(10,2)")]
    public decimal CantidadRequerida { get; set; }
}