using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Cod3rsGrowth.Tests.RepositoriesMock;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Habilidades
{
    public class TesteServicoObterTodosHabilidade : TesteBase
    {
        private readonly HabilidadeRepositorioMock _habilidadeRepositorioMock;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public TesteServicoObterTodosHabilidade() : base()
        {
            _habilidadeRepositorioMock = _serviceProvider.GetRequiredService<HabilidadeRepositorioMock>();
        }

        [Fact]
        public void ObterTodosHabilidadeRetornaLista()
        {
            // Act
            RepositorioMock.ResetarInstancia();
            var habilidades = _habilidadeRepositorioMock.ObterTodos;

            // Assert
            Assert.IsType<List<Habilidade>>(habilidades);
            Assert.Equivalent(_habilidades, habilidades);
        }
    }
}