using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
namespace RegistroTecnico.Models
{
    public class Tecnicos
    {

        [Key]
        public int TecnicoId { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]

        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El campo solo puede contener letras y espacios.")]
        public string TecNombre { get; set; }

        [Required(ErrorMessage = "El campo Sueldo Hora es obligatorio")]

        public decimal TecSueldoHora { get; set; }

        [ForeignKey("TipoTecnico")]
        [Required(ErrorMessage = "Es obligatorio seleccionar un tecnico")]

        public int TipoTecnicoId { get; set; }

        [ForeignKey("TipoTecnicoId")]

        public TipoTecnico TipoTecnico { get; set; }
    }

}
