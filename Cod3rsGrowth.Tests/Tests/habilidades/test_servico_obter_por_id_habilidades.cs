using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Cod3rsGrowth.Tests.RepositoriesMock;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Habilidades
{
    public class TesteServicoObterPorIdHabilidade : TesteBase
    {
        private readonly HabilidadeRepositorioMock _habilidadeRepositorioMock;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public TesteServicoObterPorIdHabilidade() : base()
        {
            _habilidadeRepositorioMock = _serviceProvider.GetRequiredService<HabilidadeRepositorioMock>();
        }

        [Fact]
        public void ObtemHabilidadePorIdComExito()
        {
            // Arrange
            RepositorioMock.ResetarInstancia();
            int idTeste = 1;
            var novaHabilidade = new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." };
            _habilidades.Add(novaHabilidade);

            // Act
            var personagemEncontrado = _habilidadeRepositorioMock.ObterPorId(idTeste);

            // Assert
            Assert.Equivalent(novaHabilidade, personagemEncontrado);
        }

        [Fact]
        public void DeveLancarExcecaoAoBuscarPorIdComIdInvalido()
        {
            // Arrange
            int idTeste = 2, idInvalido = 99999;
            var novaHabilidade = new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." };
            _habilidades.Add(novaHabilidade);

            // Act - Assert
            var resultado = Assert.Throws<Exception>(() => _habilidadeRepositorioMock.ObterPorId(idInvalido));
            Assert.Equal("Habilidade não encontrada.", resultado.Message);
        }
    }
}