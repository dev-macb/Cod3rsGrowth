using Microsoft.AspNetCore.Mvc;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Service.Services;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route(Constantes.URL_CONTROLLER)]
    [ApiController]
    public class PersonagemController : ControllerBase
    {
        private readonly PersonagemServico _personagemServico;

        public PersonagemController(PersonagemServico personagemServico)
        {
            _personagemServico = personagemServico;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromQuery] Filtro? filtro)
        {
            var todosPersonagens = await _personagemServico.ObterTodos(filtro);
            return Ok(todosPersonagens);
        }

        [HttpGet(Constantes.URL_PARAMETRO_ID)]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            var personagem = await _personagemServico.ObterPorId(id);
            if (personagem == null) return NotFound(id);

            return Ok(personagem);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Personagem personagem)
        {
            var idPersonagem = await _personagemServico.Adicionar(personagem);
            return Created("id", idPersonagem);
        }

        [HttpPut(Constantes.URL_PARAMETRO_ID)]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] Personagem personagem)
        {
            await _personagemServico.Atualizar(id, personagem);
            return NoContent();
        }

        [HttpDelete(Constantes.URL_PARAMETRO_ID)]
        public async Task<IActionResult> Deletar([FromRoute] int id)
        {
            await _personagemServico.Deletar(id);
            return NoContent();
        }
    }
}
