using CodersGrowth.Domain;

namespace Cod3rsGrowth.Infra
{
    public class PersonagemRepositorio : IPersonagemRepositorio
    {
        private readonly List<Personagem> personagens;

        public PersonagemRepositorio()
        {
            personagens = new List<Personagem>()
            {
                new(1, "Ryu", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(2, "Ken", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(3, "Chun-Li", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(4, "Blanka", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(5, "Zangief", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(6, "Guile", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(7, "Dhalsim", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(8, "Vega", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio)
            };
        }

        public List<Personagem> ObterTodos()
        {
            return personagens;
        }

        public Personagem? ObterPorId(int id)
        {
            return personagens.Find(personagem => personagem.Id == id);
        }

        public int Criar(Personagem personagem)
        {
            int novoId = (int)(personagens.Any() ? personagens.Max(p => p.Id) + 1 : 1);
            personagem.Id = novoId;

            personagens.Add(personagem);

            return personagem.Id ?? 0;
        }
    }
}