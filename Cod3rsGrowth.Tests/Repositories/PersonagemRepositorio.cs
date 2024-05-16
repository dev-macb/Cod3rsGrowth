using CodersGrowth.Domain.Enum;
using CodersGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;


namespace Cod3rsGrowth.Tests.Repositories
{
    public class PersonagemRepositorio : IPersonagemRepositorio
    {
        public readonly List<Personagem> personagens;

        public PersonagemRepositorio()
        {
            personagens = new List<Personagem>()
            {
                new("Ryu", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new("Ken", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new("Chun-Li", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new("Blanka", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new("Zangief", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new("Guile", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new("Dhalsim", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new("Vega", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio)
            };
        }

        public List<Personagem> ObterTodos()
        {
            return personagens;
        }
    }
}