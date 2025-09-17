using Financeiro.Domain.Entidades;
using Financeiro.Infrastructure.Data;
using Financeiro.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Financeiro.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly FinanceiroDbContext _context;

        public UsuarioRepository(FinanceiroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(Guid id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Usuario> GetByCpfAsync(string cpf)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Cpf == cpf);
        }
    }
}
