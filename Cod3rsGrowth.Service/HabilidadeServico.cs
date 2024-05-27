using Cod3rsGrowth.Infra;
using FluentValidation.Results;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Validators;

namespace Cod3rsGrowth.Service
{
    public class HabilidadeServico : IHabilidadeServico
    {
        private readonly HabilidadeValidador _habilidadeValidador;
        private readonly IHabilidadeRepositorio _habilidadeRepositorio;

        public HabilidadeServico(IHabilidadeRepositorio repositorioMock, HabilidadeValidador validador)
        {
            _habilidadeValidador = validador;
            _habilidadeRepositorio = repositorioMock;
        }

        public List<Habilidade> ObterTodos()
        {
            return _habilidadeRepositorio.ObterTodos();
        }

        public Habilidade ObterPorId(int id)
        {
            return _habilidadeRepositorio.ObterPorId(id);
        }

        public int Criar(Habilidade habilidade)
        {
            const string separador = " ";
            ValidationResult resultado = _habilidadeValidador.Validate(habilidade);
            if (!resultado.IsValid) 
            {
                string todosErros = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new Exception(todosErros);
            }

            int idNovaHabilidade = _habilidadeRepositorio.Criar(habilidade);
            
            return idNovaHabilidade;
        }

        public void Editar(int id, Habilidade habilidadeAtualizada)
        {
            const string separador = " ";
            ValidationResult resultado = _habilidadeValidador.Validate(habilidadeAtualizada);
            if (!resultado.IsValid)
            {
                string todosErros = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new Exception(todosErros);
            }

            _habilidadeRepositorio.Editar(id, habilidadeAtualizada);
        }

        public void Remover(int id)
        {
            _habilidadeRepositorio.Remover(id);
        }
    }
}