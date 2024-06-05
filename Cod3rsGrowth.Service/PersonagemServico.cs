using FluentValidation.Results;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Domain.Validators;

namespace Cod3rsGrowth.Service
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

        public IEnumerable<Personagem> ObterTodos(string filtro)
        {
            return _personagemRepositorio.ObterTodos(filtro);
        }

        public Personagem? ObterPorId(int id)
        {
            return _personagemRepositorio.ObterPorId(id);
        }

        public void Adicionar(Personagem personagem)
        {
            const string separador = " "; 
            ValidationResult resultado = _personagemValidador.Validate(personagem);
            if (!resultado.IsValid) 
            {
                string todosErros = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new Exception(todosErros);
            }

            _personagemRepositorio.Adicionar(personagem);
        }

        public void Atualizar(int id, Personagem personagemAtualizado)
        {
            const string separador = " "; 
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