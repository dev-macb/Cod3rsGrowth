using FluentValidation;
using Cod3rsGrowth.Domain.Entities;

namespace Cod3rsGrowth.Service.Validators
{
    public class HabilidadeValidador : AbstractValidator<Habilidade>
    {
        public HabilidadeValidador()
        {
            RuleFor(habilidade => habilidade.Nome)
                .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("O nome é obrigatório.")
                    .Length(3, 50).WithMessage("O nome deve ter no mínimo 3 caracteres e no máximo 50.");

            RuleFor(habilidade => habilidade.Descricao)
                .Length(0, 200).WithMessage("A descrição deve ter no mínimo 0 caracteres e no máximo 200.");
        }
    }
}