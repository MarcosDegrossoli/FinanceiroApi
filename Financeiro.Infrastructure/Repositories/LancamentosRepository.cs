using Financeiro.Domain.Entidades;
using Financeiro.Infrastructure.Data;
using Financeiro.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Financeiro.Infrastructure.Repositories
{
    public class LancamentosRepository : ILancamentosRepository
    {
        private readonly FinanceiroDbContext _context;

        public LancamentosRepository(FinanceiroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lancamento>> GetAllAsync()
        {
            return await _context.Lancamentos.ToListAsync();
        }

        public async Task<Lancamento?> GetByIdAsync(Guid id)
        {
            return await _context.Lancamentos.FindAsync(id);
        }

        public async Task<IEnumerable<Lancamento>> GetByIdConta(Guid id)
        {
            return await _context.Lancamentos
                .Where(l => l.IdConta == id)
                .ToListAsync();
        }

        public async Task AddAsync(Lancamento lancamento)
        {
            _context.Lancamentos.Add(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Lancamento lancamento)
        {
            _context.Lancamentos.Update(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);
            if (lancamento != null)
            {
                _context.Lancamentos.Remove(lancamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
