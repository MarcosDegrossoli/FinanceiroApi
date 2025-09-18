using Financeiro.Domain.Entidades;
using Financeiro.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceiroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _bancoService;

        public BancoController(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bancos = await _bancoService.GetAllAsync();
            return Ok(bancos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var banco = await _bancoService.GetByIdAsync(id);
            if (banco == null)
            {
                return NotFound();
            }
            return Ok(banco);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Banco banco)
        {
            try
            {
                await _bancoService.AddAsync(banco);
                return CreatedAtAction(nameof(GetAll), new { id = banco.IdBanco }, banco);
            }
            catch (Exception execao)
            {
                return BadRequest(execao.Message);
            }
        }
    }
}
