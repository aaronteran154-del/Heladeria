using Microsoft.EntityFrameworkCore;

namespace Heladeria // Asegúrate de usar el namespace de tu proyecto
{
    public class HeladeriaDbContext : DbContext
    {
        public HeladeriaDbContext(DbContextOptions<HeladeriaDbContext> options) : base(options)
        {
        }

        // Definición de las tablas (DbSet) para cada modelo
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<RecetaProducto> RecetaProductos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeo explícito de los nombres de las tablas en minúsculas para PostgreSQL
            modelBuilder.Entity<Proveedor>().ToTable("proveedores");
            modelBuilder.Entity<Inventario>().ToTable("inventario");
            modelBuilder.Entity<Producto>().ToTable("productos");
            modelBuilder.Entity<RecetaProducto>().ToTable("receta_productos");
            modelBuilder.Entity<Cliente>().ToTable("clientes");
            modelBuilder.Entity<Venta>().ToTable("ventas");
            modelBuilder.Entity<DetalleVenta>().ToTable("detalle_ventas");
        }
    }
}
