using Cod3rsGrowth.Domain.Entities;

namespace Cod3rsGrowth.Tests.RepositoriesMock
{
    public sealed class RepositorioMock
    {
        private static RepositorioMock? _instancia;
        public List<Personagem> Personagens { get; set; }
        public List<Habilidade> Habilidades { get; set; }

        private RepositorioMock()
        {
            Personagens = new List<Personagem>();
            Habilidades = new List<Habilidade>();
        }

        public static RepositorioMock ObterInstancia
        {
            get { return _instancia ??= new RepositorioMock(); }
        }

        public static void ResetarInstancia()
        {
            _instancia = null;
        }
    }
}