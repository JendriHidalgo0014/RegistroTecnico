﻿using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RegistroTecnico.Models
{
    public class Trabajo
    {
        [Key]

        public int TrabajoId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public string nombre { get; set; } 
        public int TecnicoId { get; set; }
        public string TecNombre { get; set; } 
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }

    }
}