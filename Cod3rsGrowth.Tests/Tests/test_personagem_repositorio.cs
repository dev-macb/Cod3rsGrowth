using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests
{
    public class TestePersonagem : TesteBase
    {
        public PersonagemRepositorio mockPersonagem;

        public TestePersonagem() : base() 
        {
            mockPersonagem = ServiceProvider.GetRequiredService<PersonagemRepositorio>();
        }

        [Fact]
        public void TestarAtaque()
        {
            // Arrange
            var personagem = mockPersonagem.ObterTodos()[0];
            var ataqueEsperado = (int)personagem.Forca * personagem.Energia;

            // Act
            var resultado = personagem.Atacar();

            // Assert
            Assert.Equal(ataqueEsperado, resultado);
        }
    }
}