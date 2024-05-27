using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Domain.Entities;

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

        public Habilidade ObterPorId(int id)
        {
            return _habilidadeRepositorio.ObterPorId(id);
        }
    }
}