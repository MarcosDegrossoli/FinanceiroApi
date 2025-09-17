using Financeiro.Domain.Entidades;
using Financeiro.Infrastructure.Interfaces;
using Financeiro.Services.Interfaces;

namespace Financeiro.Services.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Usuario> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Usuario usuario)
        {
            var usuarioExistente = await _repository.GetByCpfAsync(usuario.Cpf);

            if (usuarioExistente != null)
            {
                throw new Exception("Usuário com este CPF já existe.");
            }

            await _repository.AddAsync(usuario);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            await _repository.UpdateAsync(usuario);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
