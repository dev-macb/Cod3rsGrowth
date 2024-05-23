using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoObterPorIdPersonagem : TesteBase
    {
        private readonly IPersonagemServico _personagemService;

        public TesteServicoObterPorIdPersonagem() : base()
        {
            _personagemService = ServiceProvider.GetRequiredService<IPersonagemServico>();
        }

        [Fact]
        public void ObterPersonagemPorIdComExito()
        {
            // Arrange
            var novoPersonagem = new Personagem(null, "Ryu", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);
            var idNovoPersonagem = _personagemService.Criar(novoPersonagem);

            // Act
            var personagemEncontrado = _personagemService.ObterPorId(idNovoPersonagem);

            // Assert
            Assert.Equal(novoPersonagem, personagemEncontrado);
        }

        [Fact]
        public void TentaObterPersonagemComIdInvalido()
        {
            // Arrange
            var idInvalido = 99999;
            var novoPersonagem = new Personagem(null, "Ryu", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);
            var idNovoPersonagem = _personagemService.Criar(novoPersonagem);

            // Act - Assert
            var resultado = Assert.Throws<Exception>(() => _personagemService.ObterPorId(idInvalido));
            Assert.Equal("Personagem não encontrado.", resultado.Message);
        }
    }
}