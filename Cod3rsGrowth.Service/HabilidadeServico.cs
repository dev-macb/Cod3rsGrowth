using Cod3rsGrowth.Infra;
using CodersGrowth.Domain.Entities;
using CodersGrowth.Domain.Validators;

namespace Cod3rsGrowth.Service
{
    public class HabilidadeServico : IHabilidadeServico
    {
        private readonly IHabilidadeRepositorio habilidadeRepositorio;

        public HabilidadeServico(IHabilidadeRepositorio repositorioMock)
        {
            habilidadeRepositorio = repositorioMock;
        }

        public List<Habilidade> ObterTodos()
        {
            return habilidadeRepositorio.ObterTodos();
        }
    }
}