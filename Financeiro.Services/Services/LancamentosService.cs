using Financeiro.Domain.Entidades;
using Financeiro.Infrastructure.Interfaces;
using Financeiro.Services.Interfaces;

namespace Financeiro.Services.Services
{
    public class LancamentosService : ILancamentosService
    {
        private readonly ILancamentosRepository _lancamentosRepository;
        private readonly IContasService _contasService;

        public LancamentosService(ILancamentosRepository lancamentosRepository, IContasService contasService)
        {
            _lancamentosRepository = lancamentosRepository;
            _contasService = contasService;
        }

        public async Task<IEnumerable<Domain.Entidades.Lancamento>> GetAllAsync()
        {
            return await _lancamentosRepository.GetAllAsync();
        }

        public async Task<Domain.Entidades.Lancamento?> GetByIdAsync(Guid id)
        {
            return await _lancamentosRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Lancamento>> GetByIdContaAsync(Guid idConta)
        {
            await VerificarSeContaExiste(idConta);

            return await _lancamentosRepository.GetByIdConta(idConta);
        }

        public async Task AddAsync(Domain.Entidades.Lancamento lancamento)
        {
            await VerificarSeContaExiste(lancamento.IdConta);

            await _lancamentosRepository.AddAsync(lancamento);
        }

        public async Task UpdateAsync(Lancamento lancamento)
        {
            await _lancamentosRepository.UpdateAsync(lancamento);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _lancamentosRepository.DeleteAsync(id);
        }

        private async Task VerificarSeContaExiste(Guid idConta)
        {
            var conta = await _contasService.GetByIdAsync(idConta);
            if (conta == null)
            {
                throw new Exception("Conta não encontrada.");
            }
        }
    }
}
