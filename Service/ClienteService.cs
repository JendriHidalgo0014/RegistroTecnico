using Microsoft.EntityFrameworkCore;
using RegistroTecnico.DAL;
using RegistroTecnico.Models;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace RegistroTecnico.Service
{
    public class ClienteService
    {
        private readonly Context _context;

        public ClienteService(Context context)
        {
            _context = context;

        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Cliente.AnyAsync(C => C.ClienteId == id);
        }

        public async Task<bool> Insertar(Cliente clientes)
        {
            _context.Cliente.Add(clientes);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Cliente clientes)
        {
            _context.Cliente.Update(clientes);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Cliente clientes)
        {
            if (!await Existe(clientes.ClienteId))
                return await Insertar(clientes);
            else
                return await Modificar(clientes);

        }

        public async Task<bool> Eliminar(int id)
        {
            var eliminar = await _context.Cliente
                .Where(a => a.ClienteId == id).ExecuteDeleteAsync();
            return eliminar > 0;
        }

        public async Task<Cliente?> Buscar(int id)
        {
            return await _context.Cliente.AsNoTracking()
                .FirstOrDefaultAsync(a => a.ClienteId == id);
        }

        public async Task<List<Cliente>> Listar(Expression<Func<Cliente, bool>> criterio)
        {
            return await _context.Cliente.AsNoTracking()
               .Where(criterio)
               .ToListAsync();
        }



        public async Task<bool> ValidarNombres(string nombre)
        {
            return await _context.Cliente.AnyAsync(n => n.Nombres == nombre);
        }

        public async Task<bool> ExisteClienteWhatsApp(int WhatsApp)
        {
            return await _context.Cliente.AnyAsync(t => t.WhatsApp == WhatsApp);
        }

    }

}