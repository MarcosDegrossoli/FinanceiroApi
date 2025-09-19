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
    }
}
