using Cod3rsGrowth.Service;
using CodersGrowth.Domain.Enums;
using CodersGrowth.Domain.Entities;
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
            int listaVazia = 0;
            int idNovoPersonagem = _personagemService.Criar(new Personagem(null, "Teste", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio));

            // Act
            _personagemService.Remover(idNovoPersonagem);

            // Assert
            var quantidadePersonagens = _personagemService.ObterTodos().Count;
            Assert.Equal(listaVazia, quantidadePersonagens);
            var resultado = Assert.Throws<Exception>(() => _personagemService.ObterPorId(idNovoPersonagem));
            Assert.Equal("Personagem não encontrado.", resultado.Message);
        }

        [Fact]
        public void RemoverPersonagemComIdInvalido()
        {
            // Arrange
            int listaComUm = 1;
            int idInvalido = 99999;
            int idNovoPersonagem = _personagemService.Criar(new Personagem(null, "Teste", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio));

            // Act
            var resultado = Assert.Throws<Exception>(() => _personagemService.Remover(idInvalido));

            // Assert
            Assert.Equal("Personagem não encontrado.", resultado.Message);
            var quantidadePersonagens = _personagemService.ObterTodos().Count;
            Assert.Equal(listaComUm, quantidadePersonagens);
            var novoPersonagem = _personagemService.ObterPorId(idNovoPersonagem);
            Assert.IsType<Personagem>(novoPersonagem);
        }
    }
}