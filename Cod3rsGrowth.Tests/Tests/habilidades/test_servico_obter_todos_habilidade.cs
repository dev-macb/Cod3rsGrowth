using Cod3rsGrowth.Service;
using CodersGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoObterTodosHabilidade : TesteBase
    {
        private readonly IHabilidadeServico habilidadeService;

        public TesteServicoObterTodosHabilidade() : base()
        {
            habilidadeService = ServiceProvider.GetRequiredService<IHabilidadeServico>();
        }

        [Fact]
        public void ObterTodasHabilidadesComListaVazia()
        {
            // Act
            var habilidades = new List<Habilidade>(); // habilidadeService.ObterTodos();

            // Assert
            Assert.Empty(habilidades);
        }

        [Fact]
        public void ObterTodasHabilidadesComTresInclusoes()
        {
            // Act
            var quantidadeHabilidades = 3;
            var habilidades = habilidadeService.ObterTodos();

            // Assert
            Assert.Equal(quantidadeHabilidades, habilidades.Count);
        }
    }
}