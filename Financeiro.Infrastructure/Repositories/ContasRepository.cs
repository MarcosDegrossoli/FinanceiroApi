using Financeiro.Domain.Entidades;
using Financeiro.Infrastructure.Data;
using Financeiro.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Financeiro.Infrastructure.Repositories
{
    public class ContasRepository : IContasRepository
    {
        private readonly FinanceiroDbContext _context;

        public ContasRepository(FinanceiroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Conta>> GetAllAsync()
        {
            return await _context.Contas.ToListAsync();
        }

        public async Task<Conta?> GetByIdAsync(int id)
        {
            return await _context.Contas.FindAsync(id);
        }

        public async Task AddAsync(Conta conta)
        {
            _context.Contas.Add(conta);
            await _context.SaveChangesAsync();
        }

        public async Task<Conta> GetByNumeroConta(string numeroConta)
        {
            return await _context.Contas.FirstOrDefaultAsync(c => c.NumeroConta == numeroConta);
        }
    }
}
