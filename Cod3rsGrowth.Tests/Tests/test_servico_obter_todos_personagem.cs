using Cod3rsGrowth.Service;
using CodersGrowth.Domain.Enums;
using CodersGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoObterTodosPersonagem : TesteBase
    {
        private readonly IPersonagemServico personagemService;

        public TesteServicoObterTodosPersonagem() : base()
        {
            personagemService = ServiceProvider.GetRequiredService<IPersonagemServico>();
        }

        [Fact]
        public void ObterTodosPersonagensComExito()
        {
            // Arrange
            var personagens = personagemService.ObterTodos();

            // Assert
            Assert.Equal(9, personagens.Count);
        }

        [Fact]
        public void TentarObterTodosPersonagensComListaVazia()
        {
            // Arrange
            var personagens = GerarLista();

            

            // Act

            // Assert
            Assert.Empty(personagens);
        }

        private List<Personagem> GerarLista()
        {
            return new List<Personagem>()
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