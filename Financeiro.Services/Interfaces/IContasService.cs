using Financeiro.Domain.Entidades;

namespace Financeiro.Services.Interfaces
{
    public interface IContasService
    {
        Task<IEnumerable<Conta>> GetAllAsync();
        Task<Conta?> GetByIdAsync(int id);
        Task AddAsync(Conta conta);
    }
}
