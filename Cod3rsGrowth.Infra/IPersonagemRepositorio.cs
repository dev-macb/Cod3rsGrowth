using Cod3rsGrowth.Domain.Entities;

namespace Cod3rsGrowth.Infra
{
    public interface IPersonagemRepositorio
    {
        public List<Personagem> ObterTodos();
        public Personagem ObterPorId(int id);
        public int Criar(Personagem personagem);
        public void Editar(int id, Personagem personagem);
        public void Remover(int id);
    }
}