using System.ComponentModel.DataAnnotations;
namespace RegistroTecnico.Models
{
    public class Tecnicos
    {

        [Key]
        public int TecId { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")] 

        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El campo solo puede contener letras y espacios.")]
        public string TecNombre { get; set; }

        [Required(ErrorMessage = "El campo Sueldo Hora es obligatorio")]

        public decimal TecSueldoHora { get; set; }


    }
    
}
