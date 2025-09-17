using Financeiro.Domain.Entidades;

namespace Financeiro.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(Guid id);
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(Guid id);
        Task<Usuario> GetByCpfAsync(string cpf);
    }
}
