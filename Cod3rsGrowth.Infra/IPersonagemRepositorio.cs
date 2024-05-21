using CodersGrowth.Domain.Entities;

namespace Cod3rsGrowth.Infra
{
    public interface IPersonagemRepositorio
    {
        public List<Personagem> ObterTodos();
        public Personagem? ObterPorId(int id);
        public int Criar(Personagem personagem);
    }
}