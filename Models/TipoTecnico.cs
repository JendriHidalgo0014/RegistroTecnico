using System.ComponentModel.DataAnnotations;

namespace RegistroTecnico.Models
{
    public class TipoTecnico
    {
        [Key]
        public int TipoTecnicoId { get; set; }

       [Required(ErrorMessage = "Debe colocar una descripcion")]

       public string Descripcion { get; set; }

    }
}
