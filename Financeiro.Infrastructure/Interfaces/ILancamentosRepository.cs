using Financeiro.Domain.Entidades;

namespace Financeiro.Infrastructure.Interfaces
{
    public interface ILancamentosRepository
    {
        Task<IEnumerable<Lancamento>> GetAllAsync();
        Task<Lancamento?> GetByIdAsync(Guid id);
        Task<IEnumerable<Lancamento>> GetByIdConta(Guid id);
        Task AddAsync(Lancamento lancamento);
        Task UpdateAsync(Lancamento lancamento);
        Task DeleteAsync(Guid id);
    }
}
