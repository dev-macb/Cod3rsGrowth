using FluentValidation.Results;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Service.Validators;
using FluentValidation;

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

        public IEnumerable<Personagem> ObterTodos(Filtro? filtro)
        {
            return _personagemRepositorio.ObterTodos(filtro);
        }

        public Personagem? ObterPorId(int id)
        {
            return _personagemRepositorio.ObterPorId(id);
        }

        public int Adicionar(Personagem personagem)
        {
            const string separador = "\n";
            ValidationResult resultado = _personagemValidador.Validate(personagem);
            if (!resultado.IsValid)
            {
                string todosErros = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new ValidationException(todosErros);
            }

            return _personagemRepositorio.Adicionar(personagem);
        }

        public void Atualizar(int id, Personagem personagemAtualizado)
        {
            const string separador = "\n";
            ValidationResult resultado = _personagemValidador.Validate(personagemAtualizado);
            if (!resultado.IsValid)
            {
                string todosErros = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new Exception(todosErros);
            }
            _personagemRepositorio.ObterPorId(id);

            _personagemRepositorio.Atualizar(id, personagemAtualizado);
        }

        public void Deletar(int id)
        {
            _personagemRepositorio.Deletar(id);
        }
    }
}