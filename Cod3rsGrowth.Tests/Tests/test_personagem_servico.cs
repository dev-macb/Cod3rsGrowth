using Cod3rsGrowth.Service;
using CodersGrowth.Domain.Enums;
using CodersGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TestePersonagemServicos : TesteBase
    {
        private readonly IPersonagemServico personagemService;

        public TestePersonagemServicos() : base()
        {
            personagemService = ServiceProvider.GetRequiredService<IPersonagemServico>();
        }

        [Fact]
        public void TestarCriarNovoPersonagem()
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
        public void TestarCriarNovoPersonagemInvalido()
        {
            // Arrange
            var personagemInvalido = new Personagem(null, "", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);

            // Act - Assert
            var resultado = Assert.Throws<Exception>(() => personagemService.Criar(personagemInvalido));
            Assert.Equal("Falha na validação do personagem", resultado.Message);
        }

        [Fact]
        public void NovoTeste()
        {
            // Arrange
            var personagemOriginal = new Personagem(null, "Testudo", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);
            int idNovoPersonagem = personagemService.Criar(personagemOriginal);
            var novoPersonagem = personagemService.ObterPorId(idNovoPersonagem);

            // Act
            novoPersonagem.Nome = "Testudo Alterado";
            novoPersonagem.Vida = 10;
            personagemService.Editar(idNovoPersonagem, novoPersonagem);

            // Assert
            var personagemAtualizado = personagemService.ObterPorId(idNovoPersonagem);
            Assert.Equal("Testudo Alterado", personagemAtualizado.Nome);
            Assert.Equal(10, personagemAtualizado.Vida);
        }
    }
}