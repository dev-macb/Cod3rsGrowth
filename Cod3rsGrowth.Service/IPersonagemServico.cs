using CodersGrowth.Domain.Entities;

namespace Cod3rsGrowth.Service
{
    public interface IPersonagemServico
    {
        public List<Personagem> ObterTodos();
        public Personagem? ObterPorId(int id);
        public int Criar(Personagem personagem);
    }
}
