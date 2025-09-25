using Financeiro.Domain.Entidades;
using Financeiro.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceiroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IContasService _contasService;

        public ContasController(IContasService contasService)
        {
            _contasService = contasService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contas = await _contasService.GetAllAsync();
            return Ok(contas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var conta = await _contasService.GetByIdAsync(id);
            if (conta == null)
            {
                return NotFound();
            }
            return Ok(conta);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Conta conta)
        {
            try
            {
                await _contasService.AddAsync(conta);
                return CreatedAtAction(nameof(GetAll), new { id = conta.IdConta }, conta);
            }
            catch (Exception execao)
            {
                return BadRequest(execao.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Conta conta)
        {
            try
            {
                if (id != conta.IdConta)
                {
                    return BadRequest();
                }
                await _contasService.UpdateAsync(conta);

                var contaAtualizada = await _contasService.GetByIdAsync(id);

                return Ok(contaAtualizada);
            }
            catch (Exception execao)
            {
                return BadRequest(execao.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _contasService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception execao)
            {
                return BadRequest(execao.Message);
            }
        }
    }
}
