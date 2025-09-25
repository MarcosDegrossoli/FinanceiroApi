using Financeiro.Domain.Entidades;

namespace Financeiro.Infrastructure.Interfaces
{
    public interface IContasRepository
    {
        Task<IEnumerable<Conta>> GetAllAsync();
        Task<Conta?> GetByIdAsync(Guid id);
        Task AddAsync(Conta conta);
        Task UpdateAsync(Conta conta);
        Task<Conta> GetByNumeroConta(string numeroConta);
        Task DeleteAsync(Guid id);
    }
}
