using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnico.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Tiempo es obligatorio")]
        public TimeSpan Tiempo { get; set; }  // Usando TimeSpan para representar el tiempo.
    }
}
