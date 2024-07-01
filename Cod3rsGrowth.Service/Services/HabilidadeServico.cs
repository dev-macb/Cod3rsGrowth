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

        public async Task<int> Adicionar(Habilidade habilidade)
        {
            //const string separador = "\n";
            ValidationResult resultado = await _habilidadeValidador.ValidateAsync(habilidade);
            if (!resultado.IsValid)
            {
                //string todosErros = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new ValidationException(resultado.Errors);
            }

            return await _habilidadeRepositorio.Adicionar(habilidade);
        }

        public async Task Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            habilidadeAtualizada.Id = id;

            //const string separador = "\n";
            ValidationResult resultado = await _habilidadeValidador.ValidateAsync(habilidadeAtualizada);
            if (!resultado.IsValid)
            {
                //string todosErros = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new ValidationException(resultado.Errors);
            }

            await _habilidadeRepositorio.Atualizar(id, habilidadeAtualizada);
        }

        public async Task Deletar(int id)
        {
            var habilidadeExistente = _habilidadeRepositorio.ObterPorId(id);
            if (habilidadeExistente.Result == null) throw new ValidationException("Habilidade inexistente");

            await _habilidadeRepositorio.Deletar(id);
        }
    }
}