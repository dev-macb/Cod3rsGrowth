using Cod3rsGrowth.Domain.Entities;

namespace Cod3rsGrowth.Tests.Repositories
{
    public sealed class RepositorioMock
    {
        private static RepositorioMock? _instance;
        public List<Personagem> Personagens { get; set; }
        public List<Habilidade> Habilidades { get; set; }

        private RepositorioMock() 
        {
            Personagens = new List<Personagem>(); 
            Habilidades = new List<Habilidade>();
        }

        public static RepositorioMock ObterInstancia
        {
            get { return _instance ??= new RepositorioMock(); }
        }

        public static void ResetarInstancia()
        {
            _instance = null;
        }
    }
}