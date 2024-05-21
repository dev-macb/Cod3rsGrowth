using Cod3rsGrowth.Service;
using CodersGrowth.Domain.Enums;
using CodersGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoCriarPersonagem : TesteBase
    {
        private readonly IPersonagemServico personagemService;

        public TesteServicoCriarPersonagem() : base()
        {
            personagemService = ServiceProvider.GetRequiredService<IPersonagemServico>();
        }

        [Fact]
        public void CriarNovoPersonagemComExito()
        {
             // Arrange
            var novoPersonagem = new Personagem(null, "Teste da Silva", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);

            // Act
            var resultado = personagemService.Criar(novoPersonagem);
            var personagemCriado = personagemService.ObterPorId(resultado);

            // Assert
            Assert.NotNull(personagemCriado);
            Assert.Equal(personagemCriado.Id, resultado);
            Assert.Equal(novoPersonagem.Nome, personagemCriado.Nome);
        }

        [Fact]
        public void TentarCriarNovoPersonagemComNomeCurto()
        {
            // Arrange
            var personagemInvalido = new Personagem(null, "", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);

            // Act - Assert
            Assert.Throws<Exception>(() => personagemService.Criar(personagemInvalido));
        }
    }
}