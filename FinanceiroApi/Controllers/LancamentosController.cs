using Financeiro.Domain.Entidades;
using Financeiro.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceiroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private readonly ILancamentosService _lancamentosService;
        public LancamentosController(ILancamentosService lancamentosService)
        {
            _lancamentosService = lancamentosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lancamentos = await _lancamentosService.GetAllAsync();
            return Ok(lancamentos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var lancamento = await _lancamentosService.GetByIdAsync(id);
            if (lancamento == null)
            {
                return NotFound();
            }
            return Ok(lancamento);
        }

        [HttpGet("porconta/{idConta}")]
        public async Task<IActionResult> GetByIdConta(Guid idConta)
        {
            var lancamento = await _lancamentosService.GetByIdContaAsync(idConta);
            if (lancamento == null)
            {
                return NotFound();
            }
            return Ok(lancamento);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Lancamento lancamento)
        {
            try
            {
                await _lancamentosService.AddAsync(lancamento);
                return CreatedAtAction(nameof(GetAll), new { id = lancamento.IdLancamento }, lancamento);
            }
            catch (Exception execao)
            {
                return BadRequest(execao.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Lancamento lancamento)
        {
            try
            {
                if (id != lancamento.IdLancamento)
                {
                    return BadRequest();
                }
                await _lancamentosService.UpdateAsync(lancamento);
                return NoContent();
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
                var lancamento = await _lancamentosService.GetByIdAsync(id);
                if (lancamento == null)
                {
                    return NotFound();
                }
                await _lancamentosService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception execao)
            {
                return BadRequest(execao.Message);
            }
        }
    }
}
