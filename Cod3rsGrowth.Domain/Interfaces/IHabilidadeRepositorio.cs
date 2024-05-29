using Cod3rsGrowth.Domain.Entities;

namespace Cod3rsGrowth.Domain.Interfaces
{
    public interface IHabilidadeRepositorio
    {
        public List<Habilidade> ObterTodos();
        public Habilidade ObterPorId(int id);
        public int Criar(Habilidade habilidade);
        public void Editar(int id, Habilidade habilidade);
        public void Remover(int id);
    }
}