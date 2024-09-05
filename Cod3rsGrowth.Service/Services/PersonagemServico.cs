using FluentValidation;
using FluentValidation.Results;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Service.Validators;
using LinqToDB.SqlQuery;

namespace Cod3rsGrowth.Service.Services
{
    public class PersonagemServico
    {
        private readonly PersonagemValidador _personagemValidador;
        private readonly IRepositorio<Personagem> _personagemRepositorio;
        private readonly IRepositorio<Habilidade> _habilidadeRepositorio;

        public PersonagemServico(IRepositorio<Personagem> personagemRepositorio, IRepositorio<Habilidade> habilidadeRepositorio, PersonagemValidador validador)
        {
            _personagemValidador = validador;
            _personagemRepositorio = personagemRepositorio;
            _habilidadeRepositorio = habilidadeRepositorio;
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
            //const string separador = "\n";
            ValidationResult resultado = _personagemValidador.Validate(personagem);
            if (!resultado.IsValid)
            {
                //string todosErros = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new ValidationException(resultado.Errors);
            }

            return await _personagemRepositorio.Adicionar(personagem);
        }

        public async Task Atualizar(int id, Personagem personagemAtualizado)
        {
            ValidationResult resultado = _personagemValidador.Validate(personagemAtualizado);
            if (!resultado.IsValid)
            {
                throw new ValidationException(resultado.Errors);
            }

            await _personagemRepositorio.ObterPorId(id);
            await _personagemRepositorio.Atualizar(id, personagemAtualizado);
        }

        public async Task Deletar(int id)
        {
            var personagemExistente = _personagemRepositorio.ObterPorId(id);
            if (personagemExistente.Result == null) throw new ValidationException("Personagem inexistente");

            await _personagemRepositorio.Deletar(id);
        }
    }
}