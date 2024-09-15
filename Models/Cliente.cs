using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RegistroTecnico.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo Nombres es obligatorio")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Debe colocar un numero de telefono")]

        public int WhatsApp { get; set; }

    }
}