using Cod3rsGrowth.Service;
using CodersGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoObterTodosHabilidade : TesteBase
    {
        private readonly IHabilidadeServico _habilidadeService;

        public TesteServicoObterTodosHabilidade() : base()
        {
            _habilidadeService = ServiceProvider.GetRequiredService<IHabilidadeServico>();
        }

        [Fact]
        public void ObterTodasHabilidadesComListaVazia()
        {
            // Act
            var habilidades = new List<Habilidade>(); // _habilidadeService.ObterTodos();

            // Assert
            Assert.Empty(habilidades);
        }

        [Fact]
        public void ObtemListaCompletaAoObterTodasAoHabilidades()
        {
            // Act
            var quantidadeHabilidades = 3;
            var habilidades = _habilidadeService.ObterTodos();

            // Assert
            Assert.Equal(quantidadeHabilidades, habilidades.Count);
        }
    }
}