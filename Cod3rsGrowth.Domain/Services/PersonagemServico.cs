using Cod3rsGrowth.Domain.Interfaces;

namespace Cod3rsGrowth.Domain.Services
{
    public class PersonagemServico : IPersonagemServico
    {        
        public bool ValidarObterPorId(int id)
        {
            return id > 0;
        }
    }
}