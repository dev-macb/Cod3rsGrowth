using FluentValidation.Results;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Service.Validators;
using FluentValidation;
using System.Diagnostics.Metrics;

namespace Cod3rsGrowth.Service.Services
{
    public class PersonagemServico
    {
        private readonly PersonagemValidador _personagemValidador;
        private readonly IRepositorio<Personagem> _personagemRepositorio;

        public PersonagemServico(IRepositorio<Personagem> repositorioMock, PersonagemValidador validador)
        {
            _personagemValidador = validador;
            _personagemRepositorio = repositorioMock;
        }

        public async Task<IEnumerable<Personagem>> ObterTodos(Filtro? filtro)
        {
            return await _personagemRepositorio.ObterTodos(filtro);
        }

        public async Task<Personagem?> ObterPorId(int id)
        {
            return await _personagemRepositorio.ObterPorId(id);
        }

        public async Task<int> Adicionar(Personagem personagem)
        {
            const string separador = "\n";
            ValidationResult resultado = _personagemValidador.Validate(personagem);
            if (!resultado.IsValid)
            {
                string todosErros = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new ValidationException(todosErros);
            }

            return await _personagemRepositorio.Adicionar(personagem);
        }

        public async Task Atualizar(int id, Personagem personagemAtualizado)
        {
            const string separador = "\n";
            ValidationResult resultado = _personagemValidador.Validate(personagemAtualizado);
            if (!resultado.IsValid)
            {
                string todosErros = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new Exception(todosErros);
            }

            await _personagemRepositorio.ObterPorId(id);
            await _personagemRepositorio.Atualizar(id, personagemAtualizado);
        }

        public async Task Deletar(int id)
        {
            await _personagemRepositorio.Deletar(id);
        }
    }
}