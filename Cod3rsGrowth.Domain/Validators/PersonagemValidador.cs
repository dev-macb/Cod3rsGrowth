using FluentValidation;
using CodersGrowth.Domain.Entities;

namespace CodersGrowth.Domain.Validators
{
    public class PersonagemValidador : AbstractValidator<Personagem>
    {
        public PersonagemValidador()
        {
            RuleFor(personagem => personagem.Id)
                .GreaterThanOrEqualTo(1).WithMessage("O id deve ser maior que 0.");

            RuleFor(personagem => personagem.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(3, 50).WithMessage("O nome deve ter no mínimo 5 caracteres e no máximo 50.");

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
}