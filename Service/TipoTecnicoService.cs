using Microsoft.EntityFrameworkCore;
using RegistroTecnico.DAL;
using RegistroTecnico.Models;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace RegistroTecnico.Service
{
    public class TipoTecnicoService
    {
        private readonly Context _context;

        public TipoTecnicoService(Context context)
        {
            _context = context;

        }

        public async Task<bool> Existe(int id)
        {
            return await _context.TipoTecnico.AnyAsync(T => T.TipoTecnicoId == id);
        }

        public async Task<bool> Insertar(TipoTecnico tecnicos)
        {
            _context.TipoTecnico.Add(tecnicos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(TipoTecnico tecnicos)
        {
            _context.TipoTecnico.Update(tecnicos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(TipoTecnico tecnicos)
        {
            if (!await Existe(tecnicos.TipoTecnicoId))
                return await Insertar(tecnicos);
            else
                return await Modificar(tecnicos);

        }

        public async Task<bool> Eliminar(int id)
        {
            var eliminar = await _context.TipoTecnico
                .Where(a => a.TipoTecnicoId == id).ExecuteDeleteAsync();
            return eliminar > 0;
        }

        public async Task<TipoTecnico?> Buscar(int id)
        {
            return await _context.TipoTecnico.AsNoTracking()
                .FirstOrDefaultAsync(a => a.TipoTecnicoId == id);
        }

        public async Task<List<TipoTecnico>> Listar(Expression<Func<TipoTecnico, bool>> criterio)
        {
            return await _context.TipoTecnico.AsNoTracking()
               .Where(criterio)
               .ToListAsync();
        }



        public async Task<bool> ValidarTecNombre(string nombre)
        {
            return await _context.Tecnicos.AnyAsync(n => n.TecNombre == nombre);
        }

        public async Task<bool> ExisteTecnicoDescripcion(string Descripcion)
        {
            return await _context.TipoTecnico.AnyAsync(t => t.Descripcion == Descripcion);
        }

    }

}