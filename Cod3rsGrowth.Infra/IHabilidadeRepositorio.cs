using CodersGrowth.Domain.Entities;

namespace Cod3rsGrowth.Infra
{
    public interface IHabilidadeRepositorio
    {
        public List<Habilidade> ObterTodos();
    }
}