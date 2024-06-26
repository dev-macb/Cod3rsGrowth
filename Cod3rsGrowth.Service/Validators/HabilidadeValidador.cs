using FluentValidation;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;

namespace Cod3rsGrowth.Service.Validators
{
    public class HabilidadeValidador : AbstractValidator<Habilidade>
    {
        private readonly IRepositorio<Habilidade> _habilidadeRepositorio;

        public HabilidadeValidador(IRepositorio<Habilidade> habilidadeRepositorio)
        {
            _habilidadeRepositorio = habilidadeRepositorio;

            RuleFor(habilidade => habilidade.Nome)
                .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("O nome é obrigatório.")
                    .Must(VerificaUnicidadeDoNome).WithMessage("Já existe uma habilidade com esse nome.")
                    .Length(3, 50).WithMessage("O nome deve ter no mínimo 3 caracteres e no máximo 50.");

            RuleFor(habilidade => habilidade.Descricao)
                .Length(0, 200).WithMessage("A descrição deve ter no mínimo 0 caracteres e no máximo 200.");
        }

        private bool VerificaUnicidadeDoNome(Habilidade habilidade, string nome)
        {
            return _habilidadeRepositorio.ObterTodos(new Filtro{ Nome = nome }) == null;
        }
    }
}