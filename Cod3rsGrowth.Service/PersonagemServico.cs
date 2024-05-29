using FluentValidation.Results;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Domain.Validators;

namespace Cod3rsGrowth.Service
{
    public class PersonagemServico
    {
        private readonly PersonagemValidador _personagemValidador;
        private readonly IPersonagemRepositorio _personagemRepositorio;

        public PersonagemServico(IPersonagemRepositorio repositorioMock, PersonagemValidador validador)
        {
            _personagemValidador = validador;
            _personagemRepositorio = repositorioMock;
        }

        public List<Personagem> ObterTodos()
        {
            return _personagemRepositorio.ObterTodos();
        }

        public Personagem ObterPorId(int id)
        {
            return _personagemRepositorio.ObterPorId(id);
        }

        public int Criar(Personagem personagem)
        {
            const string separador = " "; 
            ValidationResult resultado = _personagemValidador.Validate(personagem);
            if (!resultado.IsValid) 
            {
                string todosErros = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new Exception(todosErros);
            }

            int idNovoPersonagem = _personagemRepositorio.Criar(personagem);
            
            return idNovoPersonagem;
        }

        public void Editar(int id, Personagem personagemAtualizado)
        {
            const string separador = " "; 
            ValidationResult resultado = _personagemValidador.Validate(personagemAtualizado);
            if (!resultado.IsValid)
            {
                string todosErros = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new Exception(todosErros);
            }
            _personagemRepositorio.ObterPorId(id);

            _personagemRepositorio.Editar(id, personagemAtualizado);
        }

        public void Remover(int id)
        {
            _personagemRepositorio.Remover(id);
        }
    }
}