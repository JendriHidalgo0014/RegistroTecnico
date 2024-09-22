using Microsoft.EntityFrameworkCore;
using RegistroTecnico.DAL;
using RegistroTecnico.Models;
using System.Linq;
using System.Linq.Expressions;

namespace RegistroTecnico.Service
{
    public class PrioridadService
    {
        private readonly Context _context;

        public PrioridadService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Prioridades.AnyAsync(p => p.PrioridadId == id);
        }

        public async Task<bool> Insertar(Prioridades prioridad)
        {
            _context.Prioridades.Add(prioridad);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Prioridades prioridad)
        {
            _context.Prioridades.Update(prioridad);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Prioridades prioridad)
        {
            if (!await Existe(prioridad.PrioridadId))
                return await Insertar(prioridad);
            else
                return await Modificar(prioridad);
        }

        public async Task<bool> Eliminar(int id)
        {
            var prioridad = await _context.Prioridades.FindAsync(id);
            if (prioridad == null)
                return false;

            _context.Prioridades.Remove(prioridad);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Prioridades?> Buscar(int id)
        {
            return await _context.Prioridades.AsNoTracking()
                .FirstOrDefaultAsync(p => p.PrioridadId == id);
        }

        public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
        {
            return await _context.Prioridades.AsNoTracking()
               .Where(criterio)
               .ToListAsync();
        }

        public async Task<bool> ValidarDescripcion(string descripcion)
        {
            return await _context.Prioridades.AnyAsync(p => p.Descripcion == descripcion);
        }
    }
}
