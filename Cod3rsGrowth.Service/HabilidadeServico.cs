using Cod3rsGrowth.Infra;
using CodersGrowth.Domain.Entities;

namespace Cod3rsGrowth.Service
{
    public class HabilidadeServico : IHabilidadeServico
    {
        private readonly IHabilidadeRepositorio _habilidadeRepositorio;

        public HabilidadeServico(IHabilidadeRepositorio repositorioMock)
        {
            _habilidadeRepositorio = repositorioMock;
        }

        public List<Habilidade> ObterTodos()
        {
            return _habilidadeRepositorio.ObterTodos();
        }
    }
}