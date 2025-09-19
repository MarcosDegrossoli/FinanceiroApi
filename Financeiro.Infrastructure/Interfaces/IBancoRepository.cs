using Financeiro.Domain.Entidades;

namespace Financeiro.Infrastructure.Interfaces
{
    public interface IBancoRepository
    {
        Task<IEnumerable<Banco>> GetAllAsync();
        Task AddAsync(Banco banco);
        Task<Banco?> GetByIdAsync(Guid id);
        Task UpdateAsync(Banco banco);
        Task DeleteAsync(Guid id);
    }
}
