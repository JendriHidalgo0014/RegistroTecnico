using RegistroTecnico.DAL;
using RegistroTecnico.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace REGISTROTECNICO.Service
{
    public class TecnicoService
    {
        private readonly Context _context;

        public TecnicoService(Context context)
        {
            _context = context;

        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Tecnicos.AnyAsync(T => T.TecId == id);
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
            if (!await Existe(tecnicos.TecId))
                return await Insertar(tecnicos);
            else
                return await Modificar(tecnicos);

        }

        public async Task<bool> Eliminar(int id)
        {
            var eliminar = await _context.Tecnicos
                .Where(a => a.TecId == id).ExecuteDeleteAsync();
            return eliminar > 0;
        }

        public async Task<Tecnicos?> Buscar(int id)
        {
            return await _context.Tecnicos.AsNoTracking()
                .FirstOrDefaultAsync(a => a.TecId == id);
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
