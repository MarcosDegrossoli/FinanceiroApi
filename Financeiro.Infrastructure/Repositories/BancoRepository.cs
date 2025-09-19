using Financeiro.Domain.Entidades;
using Financeiro.Infrastructure.Data;
using Financeiro.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Financeiro.Infrastructure.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        private readonly FinanceiroDbContext _context;
        
        public BancoRepository(FinanceiroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Banco>> GetAllAsync()
        {
            return await _context.Bancos.ToListAsync();
        }

        public async Task<Banco?> GetByIdAsync(Guid id)
        {
            return await _context.Bancos.FindAsync(id);
        }

        public async Task AddAsync(Banco banco)
        {
            _context.Bancos.Add(banco);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Banco banco)
        {
            _context.Bancos.Update(banco);
            await _context.SaveChangesAsync();
        }
    }
}
