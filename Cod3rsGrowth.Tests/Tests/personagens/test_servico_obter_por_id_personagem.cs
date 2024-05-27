using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra;

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
            Personagem novoPersonagem = new (null, "Teste", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);
            int idNovoPersonagem = _personagemService.Criar(novoPersonagem);

            // Act
            var personagemEncontrado = _personagemService.ObterPorId(idNovoPersonagem);

            // Assert
            Assert.Equivalent(novoPersonagem, personagemEncontrado);
        }

        [Fact]
        public void DeveLancarExcecaoAoObterPorIdComIdInvalido()
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