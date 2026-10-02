using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("clientes")]
public class Cliente
{
    [Key]
    [Column("id_cliente")]
    public int IdCliente { get; set; }

    [Required]
    [StringLength(100)]
    [Column("nombre")]
    public string Nombre { get; set; }

    [StringLength(20)]
    [Column("telefono")]
    public string Telefono { get; set; }

    [StringLength(100)]
    [Column("email")]
    public string Email { get; set; }

    [Column("puntos_fidelidad")]
    public int PuntosFidelidad { get; set; } = 0;

    // Relación con ventas
    public ICollection<Venta> Ventas { get; set; }
}