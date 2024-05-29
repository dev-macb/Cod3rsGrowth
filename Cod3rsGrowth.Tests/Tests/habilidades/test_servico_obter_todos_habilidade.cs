using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoObterTodosHabilidade : TesteBase
    {
        private readonly HabilidadeServico _habilidadeService;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public TesteServicoObterTodosHabilidade() : base()
        {
            _habilidadeService = ServiceProvider.GetRequiredService<HabilidadeServico>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public void ObterTodosHabilidadeRetornaLista()
        {
            // Act
            var habilidades = _habilidadeService.ObterTodos();

            // Assert
            Assert.IsType<List<Habilidade>>(habilidades);
            Assert.Equivalent(habilidades, _habilidades);
        }
    }
}