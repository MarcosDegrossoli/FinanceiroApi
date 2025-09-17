using Financeiro.Domain.Entidades;
using Financeiro.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceiroApi.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Usuario usuario)
        {
            try
            {
                await _usuarioService.AddAsync(usuario);
                return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
            }
            catch (Exception execao)
            {
                return BadRequest(execao.Message);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Usuario usuario)
        {

            try
            {
                if (id != usuario.Id)
                {
                    return BadRequest();
                }
                await _usuarioService.UpdateAsync(usuario);

                var usuarioAtualizado = await _usuarioService.GetByIdAsync(id);

                return Ok(usuarioAtualizado);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _usuarioService.DeleteAsync(id);
            return NoContent();
        }
    }
}