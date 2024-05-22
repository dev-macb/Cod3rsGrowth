using Cod3rsGrowth.Service;
using CodersGrowth.Domain.Enums;
using CodersGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoRemoverPersonagem : TesteBase
    {
        private readonly IPersonagemServico personagemService;

        public TesteServicoRemoverPersonagem() : base()
        {
            personagemService = ServiceProvider.GetRequiredService<IPersonagemServico>();
        }

        [Fact]
        public void RemoverPersonagemComExito()
        {
            // Arrange
            int idNovoPersonagem = personagemService.Criar(new Personagem(null, "Teste", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio));

            // Act
            personagemService.Remover(idNovoPersonagem);

            // Assert
            var quantidadePersonagens = personagemService.ObterTodos().Count;
            Assert.Equal(0, quantidadePersonagens);
            var resultado = Assert.Throws<Exception>(() => personagemService.ObterPorId(idNovoPersonagem));
            Assert.Equal("Personagem não encontrado.", resultado.Message);
        }

        [Fact]
        public void RemoverPersonagemComIdInvalido()
        {
            // Arrange
            int idInvalido = 99999;
            int idNovoPersonagem = personagemService.Criar(new Personagem(null, "Teste", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio));

            // Act
            var resultado = Assert.Throws<Exception>(() => personagemService.Remover(idInvalido));

            // Assert
            Assert.Equal("Personagem não encontrado.", resultado.Message);
            var quantidadePersonagens = personagemService.ObterTodos().Count;
            Assert.Equal(1, quantidadePersonagens);
            var novoPersonagem = personagemService.ObterPorId(idNovoPersonagem);
            Assert.IsType<Personagem>(novoPersonagem);
        }
    }
}