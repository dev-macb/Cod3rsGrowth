using FluentValidation;
using Cod3rsGrowth.Infra;
using CodersGrowth.Domain;

namespace Cod3rsGrowth.Service
{
    public class PersonagemValidador : AbstractValidator<Personagem>
    {
        public PersonagemValidador()
        {
            RuleFor(personagem => personagem.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(4, 50).WithMessage("O nome deve ter no mínimo 5 caracteres.");

            RuleFor(personagem => personagem.Vida)
                .InclusiveBetween(0, 100).WithMessage("A vida deve estar entre 0 e 100.");

            RuleFor(personagem => personagem.Energia)
                .InclusiveBetween(0, 50).WithMessage("A energia deve estar entre 0 e 50.");

            RuleFor(personagem => personagem.Velocidade)
                .InclusiveBetween(0, 2).WithMessage("A velocidade deve estar entre 0 e 2.");

            RuleFor(personagem => personagem.Forca)
                .IsInEnum().WithMessage("A força deve ser um valor válido de CategoriasEnum.");

            RuleFor(personagem => personagem.Inteligencia)
                .IsInEnum().WithMessage("A inteligência deve ser um valor válido de CategoriasEnum.");
        }
    }

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