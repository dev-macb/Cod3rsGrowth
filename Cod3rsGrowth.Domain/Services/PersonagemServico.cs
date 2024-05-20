using CodersGrowth.Domain.Enum;
using CodersGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;


namespace Cod3rsGrowth.Domain.Services
{
    public class PersonagemServico : IPersonagemServico
    {        
        public bool ValidarObterPorId(int id)
        {
            return id > 0;
        }

        public bool ValidarCriar(Personagem personagem)
        {
            if (personagem.Nome.Length > 5) return false;
            if (personagem.Vida < 0 || personagem.Vida > 100) return false;
            if (personagem.Energia < 0 || personagem.Energia > 50 ) return false;
            if (personagem.Velocidade < 0 || personagem.Velocidade > 2) return false;
            if (!Enum.IsDefined(typeof(CategoriasEnum), personagem.Forca)) return false;
            if (!Enum.IsDefined(typeof(CategoriasEnum), personagem.Inteligencia)) return false;

            return true;
        }
    }
}