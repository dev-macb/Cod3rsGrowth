using Cod3rsGrowth.Infra;
using FluentValidation.Results;
using CodersGrowth.Domain.Entities;
using CodersGrowth.Domain.Validators;

namespace Cod3rsGrowth.Service
{
    public class PersonagemServico : IPersonagemServico
    {
        private readonly PersonagemValidador personagemValidador;
        private readonly IPersonagemRepositorio personagemRepositorio;

        public PersonagemServico(IPersonagemRepositorio repositorioMock, PersonagemValidador validador)
        {
            personagemValidador = validador;
            personagemRepositorio = repositorioMock;
        }

        public List<Personagem> ObterTodos()
        {
            return personagemRepositorio.ObterTodos();
        }

        public Personagem ObterPorId(int id)
        {
            return personagemRepositorio.ObterPorId(id);
        }

        public int Criar(Personagem personagem)
        {
            ValidationResult resultado = personagemValidador.Validate(personagem);
            if (!resultado.IsValid) throw new Exception(resultado.Errors.First().ErrorMessage);

            int IdNovoPersonagem = personagemRepositorio.Criar(personagem);
            
            return IdNovoPersonagem;
        }

        public void Editar(int id, Personagem personagemAtualizado)
        {
            ValidationResult resultado = personagemValidador.Validate(personagemAtualizado);
            if (!resultado.IsValid) throw new Exception(resultado.Errors.First().ErrorMessage);

            personagemRepositorio.ObterPorId(id);

            personagemRepositorio.Editar(id, personagemAtualizado);
        }

        public void Remover(int id)
        {
            personagemRepositorio.Remover(id);
        }
    }
}