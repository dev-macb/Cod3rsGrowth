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
            Exception? mensagemErro = null;
            var personagemInvalido = new Personagem(null, "", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);

            // Act
            try { personagemService.Criar(personagemInvalido); }
            catch (Exception erro) { mensagemErro = erro; }
            
            // Assert
            Assert.NotNull(mensagemErro);
            Assert.IsType<Exception>(mensagemErro);
            Assert.Equal("Falha na validação do personagem", mensagemErro.Message);
        }
    }
}