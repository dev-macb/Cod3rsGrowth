using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Service.Services;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route(Constantes.URL_CONTROLLER)]
    [ApiController]
    public class HabilidadeController : ControllerBase
    {
        private readonly HabilidadeServico _habilidadeServico;

        public HabilidadeController(HabilidadeServico habilidadeServico)
        {
            _habilidadeServico = habilidadeServico;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromQuery]Filtro? filtro)
        {
            // obter todos com filtro
            var todasHabilidades = await _habilidadeServico.ObterTodos(filtro);
            return Ok(todasHabilidades);
        }

        [HttpGet(Constantes.URL_PARAMETRO_ID)]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            // Obter por id
            var habilidade = await _habilidadeServico.ObterPorId(id);
            if (habilidade == null) return NotFound(id);

            return Ok(habilidade);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Habilidade habilidade)
        {
            // Adicionar
            int idHabilidade = await _habilidadeServico.Adicionar(habilidade);
            return Created("id", idHabilidade);
        }

        [HttpPut(Constantes.URL_PARAMETRO_ID)]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] Habilidade habilidade)
        {
            await _habilidadeServico.Atualizar(id, habilidade);
            return NoContent();
        }

        [HttpDelete(Constantes.URL_PARAMETRO_ID)]
        public async Task<IActionResult> Deletar([FromRoute] int id)
        {
            await _habilidadeServico.Deletar(id);
            return NoContent();
        }
    }
}
