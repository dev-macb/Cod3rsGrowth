using FluentValidation;
using FluentValidation.Results;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Service.Validators;

namespace Cod3rsGrowth.Service.Services
{
    public class HabilidadeServico
    {
        private readonly HabilidadeValidador _habilidadeValidador;
        private readonly IRepositorio<Habilidade> _habilidadeRepositorio;

        public HabilidadeServico(IRepositorio<Habilidade> repositorio, HabilidadeValidador validador)
        {
            _habilidadeValidador = validador;
            _habilidadeRepositorio = repositorio;
        }

        public async Task<IEnumerable<Habilidade>> ObterTodos(Filtro? filtro)
        {
            return await _habilidadeRepositorio.ObterTodos(filtro);
        }

        public async Task<Habilidade?> ObterPorId(int id)
        {
            return await _habilidadeRepositorio.ObterPorId(id);
        }

        public async Task Adicionar(Habilidade habilidade)
        {
            const string separador = "\n";
            ValidationResult resultado = _habilidadeValidador.Validate(habilidade);
            if (!resultado.IsValid)
            {
                string todosErros = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new ValidationException(todosErros);
            }

            await _habilidadeRepositorio.Adicionar(habilidade);
        }

        public async Task Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            const string separador = "\n";
            ValidationResult resultado = _habilidadeValidador.Validate(habilidadeAtualizada);
            if (!resultado.IsValid)
            {
                string todosErros = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new ValidationException(todosErros);
            }

            await _habilidadeRepositorio.Atualizar(id, habilidadeAtualizada);
        }

        public async Task Deletar(int id)
        {
            await _habilidadeRepositorio.Deletar(id);
        }
    }
}