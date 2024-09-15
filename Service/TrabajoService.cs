using Microsoft.EntityFrameworkCore;
using RegistroTecnico.DAL;
using RegistroTecnico.Models;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace RegistroTecnico.Service
{
    public class TrabajoService
    {
        private readonly Context _context;

        public TrabajoService(Context context)
        {
            _context = context;

        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Trabajo.AnyAsync(T => T.TrabajoId == id);
        }

        public async Task<bool> Insertar(Trabajo trabajo)
        {
            _context.Trabajo.Add(trabajo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Trabajo trabajo)
        {
            _context.Trabajo.Update(trabajo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Trabajo trabajo)
        {
            if (!await Existe(trabajo.TrabajoId))
                return await Insertar(trabajo);
            else
                return await Modificar(trabajo);

        }

        public async Task<bool> Eliminar(int id)
        {
            var eliminar = await _context.Trabajo
                .Where(a => a.TrabajoId == id).ExecuteDeleteAsync();
            return eliminar > 0;
        }

        public async Task<Trabajo?> Buscar(int id)
        {
            return await _context.Trabajo.AsNoTracking()
                .FirstOrDefaultAsync(a => a.TrabajoId == id);
        }

        public async Task<List<Trabajo>> Listar(Expression<Func<Trabajo, bool>> criterio)
        {
            return await _context.Trabajo.AsNoTracking()
               .Where(criterio)
               .ToListAsync();
        }



        public async Task<bool> ValidarFecha(DateTime fecha)
        {
            return await _context.Trabajo.AnyAsync(n => n.Fecha.Date == fecha.Date);
        }


        public async Task<bool> ExisteTrabajoMonto(int Monto)
        {
            return await _context.Trabajo.AnyAsync(t => t.Monto == Monto);
        }

    }

}