using Financeiro.Domain.Entidades;
using Financeiro.Infrastructure.Interfaces;
using Financeiro.Services.Interfaces;

namespace Financeiro.Services.Services
{
    public class ContasService : IContasService
    {
        public readonly IContasRepository _contasRepository;
        public readonly IBancoRepository _bancoRepository;
        public ContasService(IContasRepository repository, IBancoRepository bancoRepository)
        {
            _contasRepository = repository;
            _bancoRepository = bancoRepository;
        }

        public async Task<IEnumerable<Conta>> GetAllAsync()
        {
            return await _contasRepository.GetAllAsync();
        }

        public async Task<Conta?> GetByIdAsync(Guid id)
        {
            return await _contasRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Conta conta)
        {
            Banco? banco = await VerificarSeBancoExiste(conta);

            await VerificarDuplicidadeConta(conta, banco);

            await _contasRepository.AddAsync(conta);
        }

        public async Task UpdateAsync(Conta conta)
        {
            await _contasRepository.UpdateAsync(conta);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _contasRepository.DeleteAsync(id);
        }

        private async Task VerificarDuplicidadeConta(Conta conta, Banco? banco)
        {
            var contaExistente = await _contasRepository.GetByNumeroConta(conta.NumeroConta);

            if (contaExistente != null && contaExistente.IdBanco == banco.IdBanco)
            {
                throw new Exception("Conta com este número já existe para este banco.");
            }
        }

        private async Task<Banco?> VerificarSeBancoExiste(Conta conta)
        {
            var banco = await _bancoRepository.GetByIdAsync(conta.IdBanco);

            if (banco == null)
            {
                throw new Exception("Banco não encontrado.");
            }

            return banco;
        }
    }
}
