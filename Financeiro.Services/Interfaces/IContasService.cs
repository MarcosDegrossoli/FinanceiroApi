using Financeiro.Domain.Entidades;

namespace Financeiro.Services.Interfaces
{
    public interface IContasService
    {
        Task<IEnumerable<Conta>> GetAllAsync();
        Task<Conta?> GetByIdAsync(Guid id);
        Task AddAsync(Conta conta);
        Task UpdateAsync(Conta conta);
        Task DeleteAsync(Guid id);
    }
}
