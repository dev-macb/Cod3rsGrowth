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
            int id = 1;
            bool resultadoEsperado = true;

            // Act
            var resultado = personagemService.ValidarObterPorId(id);

            // Assert
            Assert.Equal(resultado, resultadoEsperado);
        }
    }
}