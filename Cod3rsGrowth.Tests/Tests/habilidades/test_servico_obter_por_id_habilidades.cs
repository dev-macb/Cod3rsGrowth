using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoObterPorIdHabilidade : TesteBase
    {
        private readonly IHabilidadeServico habilidadeService;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public TesteServicoObterPorIdHabilidade() : base()
        {
            habilidadeService = ServiceProvider.GetRequiredService<IHabilidadeServico>();
        }

        [Fact]
        public void ObterHabilidadePorIdComExito()
        {
            // Arrange
            Habilidade novaHabilidade = new Habilidade(10, "Teste", "Uma descrição qualquer");
            _habilidades.Add(novaHabilidade);

            // Act
            var personagemEncontrado = habilidadeService.ObterPorId(10);

            // Assert
            Assert.Equivalent(novaHabilidade, personagemEncontrado);
        }

        [Fact]
        public void TentaObterHabilidadeComIdInvalido()
        {
            // Arrange
            var idInvalido = 99999;
            Habilidade novaHabilidade = new (10, "Teste", "Uma descrição qualquer");
            _habilidades.Add(novaHabilidade);

            // Act - Assert
            var resultado = Assert.Throws<Exception>(() => habilidadeService.ObterPorId(idInvalido));
            Assert.Equal("Habilidade não encontrada.", resultado.Message);
        }
    }
}