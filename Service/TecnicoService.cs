﻿using RegistroTecnico.DAL;
using RegistroTecnico.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace RegistroTecnico.Service
{
    public class TecnicoService
    {
        private readonly Context _context;
        private object _contexto;

        public TecnicoService(Context context)
        {
            _context = context;

        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Tecnicos.AnyAsync(T => T.TecnicoId == id);
        }

        public async Task<bool> Insertar(Tecnicos tecnicos)
        {
            _context.Tecnicos.Add(tecnicos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Tecnicos tecnicos)
        {
            _context.Tecnicos.Update(tecnicos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Tecnicos tecnicos)
        {
            try
            {
                if (!await Existe(tecnicos.TecnicoId))
                    return await Insertar(tecnicos);
                else
                    return await Modificar(tecnicos);
            }
            catch (Exception ex)
            {
                // Manejo de errores: podrías registrar el error o lanzar una excepción controlada.
                Console.WriteLine($"Error en Guardar: {ex.Message}");
                return false; // Puedes devolver false si algo falla.
            }
        }


        public async Task<bool> Eliminar(int id)
        {
            var eliminar = await _context.Tecnicos
                .Where(a => a.TecnicoId == id).ExecuteDeleteAsync();
            return eliminar > 0;
        }

        public async Task<Tecnicos?> Buscar(int id)
        {
            return await _context.Tecnicos.AsNoTracking()
                .FirstOrDefaultAsync(a => a.TecnicoId == id);
        }

        public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
        {
            return await _context.Tecnicos.AsNoTracking()
               .Where(criterio)
               .ToListAsync();
        }


        public async Task<bool> ValidarTecNombre(string nombre)
        {
            return await _context.Tecnicos.AnyAsync(n => n.TecNombre == nombre); 
        }



    }

}
