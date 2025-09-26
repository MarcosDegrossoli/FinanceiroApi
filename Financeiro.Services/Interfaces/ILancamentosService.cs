namespace Financeiro.Services.Interfaces
{
    public interface ILancamentosService
    {
        Task<IEnumerable<Domain.Entidades.Lancamento>> GetAllAsync();
        Task<Domain.Entidades.Lancamento?> GetByIdAsync(Guid id);
        Task<IEnumerable<Domain.Entidades.Lancamento>> GetByIdContaAsync(Guid idConta);
        Task AddAsync(Domain.Entidades.Lancamento lancamento);
        Task UpdateAsync(Domain.Entidades.Lancamento lancamento);
        Task DeleteAsync(Guid id);
    }
}
