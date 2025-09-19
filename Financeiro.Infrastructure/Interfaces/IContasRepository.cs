using Financeiro.Domain.Entidades;

namespace Financeiro.Infrastructure.Interfaces
{
    public interface IContasRepository
    {
        Task<IEnumerable<Conta>> GetAllAsync();
        Task<Conta?> GetByIdAsync(int id);
        Task AddAsync(Conta conta);
        Task<Conta> GetByNumeroConta(string numeroConta);
    }
}
