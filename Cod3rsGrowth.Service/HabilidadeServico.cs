using FluentValidation.Results;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Domain.Validators;

namespace Cod3rsGrowth.Service
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

        public IEnumerable<Habilidade> ObterTodos(string filtro)
        {
            return _habilidadeRepositorio.ObterTodos(filtro);
        }

        public Habilidade? ObterPorId(int id)
        {
            return _habilidadeRepositorio.ObterPorId(id);
        }

        public void Adicionar(Habilidade habilidade)
        {
            const string separador = " ";
            ValidationResult resultado = _habilidadeValidador.Validate(habilidade);
            if (!resultado.IsValid) 
            {
                string todosErros = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new Exception(todosErros);
            }
            
            _habilidadeRepositorio.Adicionar(habilidade);
            // return _habilidadeRepositorio.Criar(habilidade);
        }

        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            const string separador = " ";
            ValidationResult resultado = _habilidadeValidador.Validate(habilidadeAtualizada);
            if (!resultado.IsValid)
            {
                string todosErros = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new Exception(todosErros);
            }

            _habilidadeRepositorio.Atualizar(id, habilidadeAtualizada);
        }

        public void Deletar(int id)
        {
            _habilidadeRepositorio.Deletar(id);
        }
    }
}