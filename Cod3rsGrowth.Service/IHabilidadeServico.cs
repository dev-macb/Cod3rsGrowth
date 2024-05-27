using Cod3rsGrowth.Domain.Entities;

namespace Cod3rsGrowth.Service
{
    public interface IHabilidadeServico
    {
        public List<Habilidade> ObterTodos();
        public Habilidade ObterPorId(int id);
        public int Criar(Habilidade habilidade);
        public void Editar(int id, Habilidade habilidade);
    }
}
