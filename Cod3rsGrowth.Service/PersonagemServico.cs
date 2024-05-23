using Cod3rsGrowth.Infra;
using FluentValidation.Results;
using CodersGrowth.Domain.Entities;
using CodersGrowth.Domain.Validators;

namespace Cod3rsGrowth.Service
{
    public class PersonagemServico : IPersonagemServico
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
            ValidationResult resultado = _personagemValidador.Validate(personagem);
            if (!resultado.IsValid) throw new Exception(resultado.Errors.First().ErrorMessage);

            int IdNovoPersonagem = _personagemRepositorio.Criar(personagem);
            
            return IdNovoPersonagem;
        }

        public void Editar(int id, Personagem personagemAtualizado)
        {
            ValidationResult resultado = _personagemValidador.Validate(personagemAtualizado);
            if (!resultado.IsValid) throw new Exception(resultado.Errors.First().ErrorMessage);

            _personagemRepositorio.ObterPorId(id);

            _personagemRepositorio.Editar(id, personagemAtualizado);
        }

        public void Remover(int id)
        {
            _personagemRepositorio.Remover(id);
        }
    }
}