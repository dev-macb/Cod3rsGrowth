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
        public void ObterTodosPersonagensComListaVazia()
        {
            // Act
            var personagens = personagemService.ObterTodos();

            // Assert
            Assert.Empty(personagens);
        }

        [Fact]
        public void ObterTodosPersonagensComCincoInclusoes()
        {
            // Arrange
            personagemService.Criar(new Personagem(null, "Ryu", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio));
            personagemService.Criar(new Personagem(null, "Ken", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio));
            personagemService.Criar(new Personagem(null, "Chun-Li", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio));
            personagemService.Criar(new Personagem(null, "Blanka", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio));
            personagemService.Criar(new Personagem(null, "Zangief", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio));

            // Act
            var personagens = personagemService.ObterTodos();

            // Assert
            Assert.Equal(5, personagens.Count);
        }
    }
}