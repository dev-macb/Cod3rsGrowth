﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Service.Services;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagemController : ControllerBase
    {
        private readonly PersonagemServico _personagemServico;

        public PersonagemController(PersonagemServico personagemServico)
        {
            _personagemServico = personagemServico;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var todosPersonagens = await _personagemServico.ObterTodos(null);
                return Ok(todosPersonagens);
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
                var personagem = await _personagemServico.ObterPorId(id);
                if (personagem == null) return NotFound(id);

                return Ok(personagem);
            }
            catch (Exception excecao)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, excecao.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Personagem personagem)
        {
            try
            {
                var idPersonagem = await _personagemServico.Adicionar(personagem);

                return Created("id", idPersonagem);
            }
            catch (Exception excecao)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, excecao.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(int id, Personagem personagem)
        {
            try
            {
                await _personagemServico.Atualizar(id, personagem);
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
                await _personagemServico.Deletar(id);
                return NoContent();
            }
            catch (Exception excecao)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, excecao.Message);
            }
        }
    }
}
