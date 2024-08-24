using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EFPractica.models
{
    public class Tarea
    {
        //[Key]
        public Guid TareaId { get; set; }
        //[Required]
        //[MaxLength(150)]
        public string Titulo { get; set; }
        //[ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; } //era Guid pero lo cambie a int para la practica de Seed Data (datos semilla)
        //[Required]
        //[MaxLength(500)]
        public string Descripcion { get; set; }
        //[Required]
        public Prioridad PrioridadTarea { get; set; }
        //[Required]
        public DateTime FechaCreacion { get; set; }
        public virtual Categoria Categoria { get; set; }
        // [NotMapped]
        public string Resumen { get; set; }

    }


    public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }
}

