using CodersGrowth.Domain;

namespace Cod3rsGrowth.Service
{
    public interface IPersonagemServico
    {
        // public List<Personagem> ObterTodos(string filtro);
        // public bool ValidarObterTodos(string filtro);

        // public Personagem ObterPorId(int id);
        // public bool ValidarObterPorId(int id);

        public int Criar(Personagem personagem);

        // public void Editar(int id);
        // public bool ValidarEditar(int id);

        // public void Remover(int id);
        // public bool ValidarRemover(int id);
    }
}
