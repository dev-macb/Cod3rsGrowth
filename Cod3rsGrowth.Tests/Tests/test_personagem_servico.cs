using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Service;
using CodersGrowth.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TestePersonagemServicos : TesteBase
    {
        private readonly IPersonagemServico personagemService;
        private readonly IPersonagemRepositorio personagemRepositorio;

        public TestePersonagemServicos() : base()
        {
            personagemService = ServiceProvider.GetRequiredService<IPersonagemServico>();
            personagemRepositorio = ServiceProvider.GetRequiredService<IPersonagemRepositorio>();
        }

        [Fact]
        public void TestarObterTodos()
        {
             // Arrange
            var novoPersonagem = new Personagem("NovoPersonagem", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);

            // Act
            var idCriado = personagemService.Criar(novoPersonagem);

            // Assert
            Assert.Equal(9, idCriado);
            var personagemCriado = personagemRepositorio.ObterTodos("NovoPersonagem").FirstOrDefault();
            Assert.NotNull(personagemCriado);
            Assert.Equal(novoPersonagem.Nome, personagemCriado.Nome);
        }
    }
}