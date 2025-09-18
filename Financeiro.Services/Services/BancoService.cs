using Financeiro.Domain.Entidades;
using Financeiro.Infrastructure.Interfaces;
using Financeiro.Services.Interfaces;

namespace Financeiro.Services.Services
{
    public class BancoService : IBancoService
    {
        private readonly IBancoRepository _bancoRepository;
        public BancoService(IBancoRepository bancoRepository)
        {
            _bancoRepository = bancoRepository;
        }

        public async Task<IEnumerable<Banco>> GetAllAsync()
        {
            return await _bancoRepository.GetAllAsync();
        }

        public async Task AddAsync(Banco banco)
        {
            await _bancoRepository.AddAsync(banco);
        }
    }
}
