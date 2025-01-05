using Ecommerce.Models;
using Ecommerce.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Ecommerce.Datos.Data
{
    public class EcommerceContext : DbContext
    {
        public  EcommerceContext(DbContextOptions<EcommerceContext> options) : base (options)
         
        {
        
        }

        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<ProductoImagen> ProductoImagenes { get; set; }
        public virtual DbSet<Categoria> Categorias  { get; set; }
      
        public virtual DbSet<Orden> Ordenes { get; set; }
        public virtual DbSet<OrdenProducto> OrdenProductos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<Ciudad> Ciudades { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>()
       .HasMany(c => c.Productos) // Relación 1:N
       .WithOne(p => p.Categoria) // Producto tiene una Categoría
       .HasForeignKey("CategoriaId") // Clave foránea en Producto
       .OnDelete(DeleteBehavior.Cascade); // Eliminación/actualización en cascada

            // Configuración para Ciudad y Cliente (1:N)
            modelBuilder.Entity<Ciudad>()
                .HasMany(c => c.Clientes)
                .WithOne(c => c.Ciudad)
                .HasForeignKey("CiudadId")
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración para Cliente y Orden (1:N)
            modelBuilder.Entity<Orden>()
                .HasOne(o => o.Cliente)
                .WithMany()
                .HasForeignKey("ClienteId")
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración para Orden y OrdenProducto (1:N)
            modelBuilder.Entity<OrdenProducto>()
                .HasOne(op => op.Orden)
                .WithMany(o => o.OrdenProductos)
                .HasForeignKey("OrdenId")
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración para Producto y OrdenProducto (1:N)
            modelBuilder.Entity<OrdenProducto>()
                .HasOne(op => op.Producto)
                .WithMany()
                .HasForeignKey("ProductoId")
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración para Producto y ProductoImagen (1:N)
            modelBuilder.Entity<ProductoImagen>()
                .HasOne(pi => pi.Producto)
                .WithMany()
                .HasForeignKey("ProductoId")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
