using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("proveedores")]
public class Proveedor
{
    [Key]
    [Column("id_proveedor")]
    public int IdProveedor { get; set; }

    [Required]
    [StringLength(100)]
    [Column("nombre")]
    public string Nombre { get; set; }

    [StringLength(100)]
    [Column("contacto")]
    public string Contacto { get; set; }

    [StringLength(20)]
    [Column("telefono")]
    public string Telefono { get; set; }

    [StringLength(100)]
    [Column("email")]
    public string Email { get; set; }

    // Relación de uno a muchos con Inventario
    public ICollection<Inventario> Inventarios { get; set; }
}