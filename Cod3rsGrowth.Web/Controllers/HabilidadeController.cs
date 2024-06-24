using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Service.Services;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabilidadeController : ControllerBase
    {
        private readonly HabilidadeServico _habilidadeServico;

        public HabilidadeController(HabilidadeServico habilidadeServico)
        {
            _habilidadeServico = habilidadeServico;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var todasHabilidades = await _habilidadeServico.ObterTodos(null);
                return Ok(todasHabilidades);
            }
            catch (Exception excecao) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, excecao.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                var habilidade = await _habilidadeServico.ObterPorId(id);
                if (habilidade == null) return NotFound(id);

                return Ok(habilidade);
            }
            catch (Exception excecao)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, excecao.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Habilidade habilidade)
        {
            try
            {
                int idHabilidade = await _habilidadeServico.Adicionar(habilidade);

                return Created("id", idHabilidade);
            }
            catch (Exception excecao)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, excecao.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(int id, Habilidade habilidade)
        {
            try
            {
                await _habilidadeServico.Atualizar(id, habilidade);
                return NoContent();
            }
            catch (Exception excecao)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, excecao.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _habilidadeServico.Deletar(id);
                return NoContent();
            }
            catch (Exception excecao)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, excecao.Message);
            }
        }
    }
}
