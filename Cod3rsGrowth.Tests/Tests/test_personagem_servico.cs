using CodersGrowth.Domain.Enum;
using CodersGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Services;
using Cod3rsGrowth.Domain.Interfaces;
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
        public void TestarPersonagemServicoBuscarPorId()
        {
            // Arrange
            const int Id = 1;
            bool resultadoEsperado = true;

            // Act
            var resultado = personagemService.ValidarObterPorId(Id);

            // Assert
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Fact]
        public void TestarPersonagemServicoCriar()
        {
            // Arrange
            Personagem personagem = new(10, "Teste", 100, 50, 1.0, CategoriasEnum.Bom, CategoriasEnum.Bom);
            bool resultadoEsperado = true;

            // Act
            var resultado = personagemService.ValidarCriar(personagem);

            // Assert
            Assert.Equal(resultado, resultadoEsperado);
        }
    }
}