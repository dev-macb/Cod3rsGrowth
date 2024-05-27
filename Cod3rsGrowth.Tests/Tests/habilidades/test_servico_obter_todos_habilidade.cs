using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Entities;
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
        public void ObterTodosHabilidadeRetornaLista()
        {
            // Act
            var habilidades = _habilidadeService.ObterTodos();

            // Assert
            Assert.IsType<List<Habilidade>>(habilidades);
        }
    }
}