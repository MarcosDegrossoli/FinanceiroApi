using Financeiro.Domain.Entidades;

namespace Financeiro.Services.Interfaces
{
    public interface IBancoService
    {
        Task<IEnumerable<Banco>> GetAllAsync();
        Task AddAsync(Banco banco);
        Task<Banco?> GetByIdAsync(Guid id);
        Task UpdateAsync(Banco banco);
    }
}
