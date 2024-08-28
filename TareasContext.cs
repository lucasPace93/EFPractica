using Microsoft.EntityFrameworkCore;
using EFPractica.models;

namespace EFPractica
{
    public class TareasContext : DbContext
    {

        #region creacion de tablas en db
        public DbSet<Tareas> TareaDb { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }
        #endregion
        #region propiedades de cada tabla
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region listas categoria y tablas
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria()
            {
                CategoriaId = Guid.Parse("5e054d99-fab9-4e75-8547-15f9e577b651"),
                Nombre = "Actividades pendientes",
                Peso = 20
            });
            categoriasInit.Add(new Categoria()
            {
                CategoriaId = Guid.Parse("a814c2cc-00fa-44f8-9071-9a8b8c30174d"),
                Nombre = "Actividades personales",
                Peso = 30
            });

            List<Tareas> tareasInit = new List<Tareas>();
            tareasInit.Add(new Tareas()
            {
                TareaId = Guid.Parse("177e77c2-afb0-4bea-8103-2aeb9f9a8b60"),
                CategoriaId = Guid.Parse("5e054d99-fab9-4e75-8547-15f9e577b651"),
                PrioridadTarea = Prioridad.Media,
                Titulo = "Estudiar Api Rest",
                Descripcion = "armar un api",
                
            });
            tareasInit.Add(new Tareas()
            {
                TareaId = Guid.Parse("dd3d55f0-9d03-4bf2-9b8c-954852b00bba"),
                CategoriaId = Guid.Parse("a814c2cc-00fa-44f8-9071-9a8b8c30174d"),
                PrioridadTarea = Prioridad.Alta,
                Titulo = "Pagar la factura de luz ",
                Descripcion = "La concha de tu madre edenor",
                
            });


            #endregion

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.HasData(categoriasInit);
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.HasMany(p => p.TareaPorCategoria).WithOne(p => p.Categoria).HasForeignKey(p => p.TareaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(50);
                categoria.Property(p => p.Descripcion).IsRequired(false).HasMaxLength(1000);
                categoria.Property(p => p.Peso).IsRequired().HasMaxLength(3);

            });

            modelBuilder.Entity<Tareas>(tarea =>
            {
                tarea.HasData(tareasInit);
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);
                tarea.HasOne(p => p.Categoria).WithMany(p => p.TareaPorCategoria).HasForeignKey(p => p.CategoriaId);
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Descripcion).IsRequired();
                tarea.Property(p => p.PrioridadTarea).IsRequired();
                tarea.Ignore(p => p.Resumen);
            });
        }
        #endregion
    }
}