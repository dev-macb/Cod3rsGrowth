using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Service;
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
            // Arrange
            RepositorioMock.ResetarInstancia();

            // Act
            var habilidades = _habilidadeService.ObterTodos();

            // Assert
            Assert.Empty(habilidades);
        }

        // [Fact]
        // public void ObtemListaCompletaAoObterTodasAoHabilidades()
        // {
        //     // Act
        //     var quantidadeAntes = _habilidadeService.ObterTodos().Count;

        //     // Assert
        //     Assert.Equal(quantidadeHabilidades, habilidades.Count);
        // }
    }
}