using Cod3rsGrowth.Infra;
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
            var idCriado = personagemService.Criar(novoPersonagem);
            var personagemCriado = personagemService.ObterPorId(idCriado);

            // Assert
            Assert.NotNull(personagemCriado);
            Assert.Equal(personagemCriado.Id, idCriado);
            Assert.Equal(novoPersonagem.Nome, personagemCriado.Nome);
        }
    }
}