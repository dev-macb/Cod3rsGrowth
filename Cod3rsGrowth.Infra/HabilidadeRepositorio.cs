using Cod3rsGrowth.Domain.Entities;

namespace Cod3rsGrowth.Infra
{
    public class HabilidadeRepositorio : IHabilidadeRepositorio
    {
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public List<Habilidade> ObterTodos()
        {
            return _habilidades;
        }

        public Habilidade ObterPorId(int id)
        {
            return _habilidades.Find(habilidade => habilidade.Id == id) ?? throw new Exception("Habilidade não encontrada.");
        }
    }
}
