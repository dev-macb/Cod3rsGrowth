using Cod3rsGrowth.Domain.Entities;

namespace Cod3rsGrowth.Domain.Interfaces
{
    public interface IPersonagensHabilidadesRepositorio : IRepositorio<PersonagensHabilidades>
    {
        Task<List<int>> ObterHabilidadesPorPersonagem(int idPersonagem);
        Task DeletarPorPersonagemEHabilidade(int idPersonagem, int idHabilidade);
    }
}
