using Cod3rsGrowth.Infra;
using CodersGrowth.Domain.Entities;
using CodersGrowth.Domain.Validators;

namespace Cod3rsGrowth.Service
{
    public class PersonagemServico : IPersonagemServico
    {
        private readonly IPersonagemRepositorio personagemRepositorio;

        public PersonagemServico(IPersonagemRepositorio personagemMock)
        {
            personagemRepositorio = personagemMock;
        }

        public List<Personagem> ObterTodos()
        {
            return personagemRepositorio.ObterTodos();
        }

        public Personagem? ObterPorId(int id)
        {
            return personagemRepositorio.ObterPorId(id);
        }

        public int Criar(Personagem personagem)
        {
            var validador = new PersonagemValidador();
            FluentValidation.Results.ValidationResult resultado = validador.Validate(personagem);
            if (!resultado.IsValid) return 0;

            int IdNovoPersonagem = personagemRepositorio.Criar(personagem);
            
            return IdNovoPersonagem;
        }
    }
}