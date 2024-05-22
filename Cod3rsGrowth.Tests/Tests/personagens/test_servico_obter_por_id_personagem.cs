using Cod3rsGrowth.Service;
using CodersGrowth.Domain.Enums;
using CodersGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoObterPorIdPersonagem : TesteBase
    {
        private readonly IPersonagemServico personagemService;

        public TesteServicoObterPorIdPersonagem() : base()
        {
            personagemService = ServiceProvider.GetRequiredService<IPersonagemServico>();
        }

        [Fact]
        public void ObterPersonagemPorIdComExito()
        {
            // Arrange
            var novoPersonagem = new Personagem(null, "Ryu", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);
            var idNovoPersonagem = personagemService.Criar(novoPersonagem);

            // Act
            var personagemEncontrado = personagemService.ObterPorId(idNovoPersonagem);

            // Assert
            Assert.Equivalent(novoPersonagem, personagemEncontrado);
        }

        [Fact]
        public void TentaObterPersonagemComIdInvalido()
        {
            // Arrange
            var idInvalido = 99999;
            var novoPersonagem = new Personagem(null, "Ryu", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);
            var idNovoPersonagem = personagemService.Criar(novoPersonagem);

            // Act - Assert
            var resultado = Assert.Throws<Exception>(() => personagemService.ObterPorId(idInvalido));
            Assert.Equal("Personagem não encontrado.", resultado.Message);
        }
    }
}