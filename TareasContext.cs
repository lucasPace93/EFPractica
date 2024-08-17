using Microsoft.EntityFrameworkCore;
using EFPractica.models;

namespace EFPractica
{
    public class TareasContext : DbContext
    {
        #region creacion de tablas en db
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(50);
                categoria.Property(p => p.Descripcion).IsRequired().HasMaxLength(1000);
                categoria.Property(p => p.Peso).IsRequired().HasMaxLength(3);

            });

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);
                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tarea).HasForeignKey(p => p.CategoriaId);
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Descripcion).IsRequired();
                tarea.Property(p => p.PrioridadTarea).IsRequired();
                tarea.Property(p => p.FechaCreacion).IsRequired();
                tarea.Ignore(p => p.Resumen);
            });
        }
    }
}