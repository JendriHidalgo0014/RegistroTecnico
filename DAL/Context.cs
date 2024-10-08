﻿using Microsoft.EntityFrameworkCore;
using RegistroTecnico.Models;

namespace RegistroTecnico.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Tecnicos> Tecnicos { get; set; }

        public DbSet<TipoTecnico> TipoTecnico { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Trabajo> Trabajo { get; set; }

        public DbSet<Prioridades> Prioridades { get; set; }



    }

}