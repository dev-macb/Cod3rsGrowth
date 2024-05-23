using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoObterTodosPersonagem : TesteBase
    {
        private readonly IPersonagemServico _personagemService;

        public TesteServicoObterTodosPersonagem() : base()
        {
            _personagemService = ServiceProvider.GetRequiredService<IPersonagemServico>();
        }

        [Fact]
        public void ObterTodosPersonagensComListaVazia()
        {
            // Arrange
            RepositorioMock.ResetarInstancia();

            // Act
            var personagens = _personagemService.ObterTodos();

            // Assert
            Assert.Empty(personagens);
        }

        [Fact]
        public void ObterTodosPersonagensComCincoInclusoes()
        {
            // Arrange
            RepositorioMock.ResetarInstancia();
            int quantidadeDeInclusoes = 5;
            int quantidadeAntes = _personagemService.ObterTodos().Count;
            _personagemService.Criar(new Personagem(null, "Ryu", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio));
            _personagemService.Criar(new Personagem(null, "Ken", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio));
            _personagemService.Criar(new Personagem(null, "Chun-Li", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio));
            _personagemService.Criar(new Personagem(null, "Blanka", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio));
            _personagemService.Criar(new Personagem(null, "Zangief", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio));

            // Act
            var personagens = _personagemService.ObterTodos();

            // Assert
            Assert.Equal(personagens.Count, quantidadeAntes + quantidadeDeInclusoes);
        }
    }
}