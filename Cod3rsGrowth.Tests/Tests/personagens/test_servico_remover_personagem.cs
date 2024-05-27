using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoRemoverPersonagem : TesteBase
    {
        private readonly IPersonagemServico _personagemService;

        public TesteServicoRemoverPersonagem() : base()
        {
            _personagemService = ServiceProvider.GetRequiredService<IPersonagemServico>();
        }

        [Fact]
        public void RemoverPersonagemComExito()
        {
            // Arrange
            int idNovoPersonagem = _personagemService.Criar(new Personagem(null, "Teste", 100, 50, 1.0, CategoriasEnum.Bom, CategoriasEnum.Medio));
            
            // Act
            _personagemService.Remover(idNovoPersonagem);

            // Assert
            var excecao = Assert.Throws<Exception>(() => _personagemService.ObterPorId(idNovoPersonagem));
            Assert.Equal("Personagem não encontrado.", excecao.Message);
        }

        [Fact]
        public void RemoverPersonagemComIdInvalido()
        {
            // Arrange
            int idInvalido = 99999;
            int idNovoPersonagem = _personagemService.Criar(new Personagem(null, "Teste", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio));

            // Act
            var resultado = Assert.Throws<Exception>(() => _personagemService.Remover(idInvalido));

            // Assert
            Assert.Equal("Personagem não encontrado.", resultado.Message);
        }
    }
}