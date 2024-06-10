using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Habilidades
{
    public class TesteServicoObterTodosHabilidade : TesteBase
    {
        private readonly HabilidadeServico _habilidadeService;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public TesteServicoObterTodosHabilidade() : base()
        {
            _habilidadeService = _serviceProvider.GetRequiredService<HabilidadeServico>();
        }

        [Fact]
        public void ObterTodosHabilidadeRetornaLista()
        {
            // Act
            RepositorioMock.ResetarInstancia();
            var habilidades = _habilidadeService.ObterTodos("");

            // Assert
            Assert.IsType<List<Habilidade>>(habilidades);
            Assert.Equivalent(_habilidades, habilidades);
        }
    }
}