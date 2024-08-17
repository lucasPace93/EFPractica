
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFPractica.models
{
    public class Categoria
    {
        //[Key]
        public Guid CategoriaId { get; set; }
        //[Required]
        //[MaxLength(150)]
        public string Nombre { get; set; }
        // [Required]
        // [MaxLength(500)]
        public string Descripcion { get; set; }
        //[Required]
        public int Peso { get; set; }
        // [ForeignKey("TareaId")]
        public virtual ICollection<Tarea> Tarea { get; set; }

    }
}