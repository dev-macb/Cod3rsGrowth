using CodersGrowth.Domain.Enum;
using CodersGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;


namespace Cod3rsGrowth.Tests.Repositories
{
    public class PersonagemRepositorio : IPersonagemRepositorio
    {
        public List<Personagem> personagens;

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
    }
}