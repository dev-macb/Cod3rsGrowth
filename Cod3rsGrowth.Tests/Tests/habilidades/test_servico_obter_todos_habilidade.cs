using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Service.Services;
using Cod3rsGrowth.Tests.RepositoriesMock;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Habilidades
{
    public class TesteServicoObterTodosHabilidade : TesteBase
    {
        private readonly HabilidadeServico _habilidadeServico;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public TesteServicoObterTodosHabilidade() : base()
        {
            _habilidadeServico = _serviceProvider.GetRequiredService<HabilidadeServico>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public async void ObterTodosHabilidadeRetornaLista()
        {
            // Act
            var habilidades = await _habilidadeServico.ObterTodos(new Filtro());

            // Assert
            Assert.IsType<List<Habilidade>>(habilidades);
            Assert.Equivalent(_habilidades, habilidades);
        }
    }
}