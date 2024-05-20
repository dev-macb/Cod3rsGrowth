using CodersGrowth.Domain.Entities;

namespace Cod3rsGrowth.Domain.Interfaces
{
    public interface IPersonagemServico
    {
        bool ValidarObterPorId(int id);
        bool ValidarCriar(Personagem personagem);
    }
}
