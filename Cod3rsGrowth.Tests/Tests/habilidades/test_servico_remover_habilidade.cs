using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Cod3rsGrowth.Tests.RepositoriesMock;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Habilidades
{
    public class TesteServicoDeletarHabilidade : TesteBase
    {
        private readonly HabilidadeRepositorioMock _habilidadeRepositorioMock;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public TesteServicoDeletarHabilidade() : base()
        {
            _habilidadeRepositorioMock = _serviceProvider.GetRequiredService<HabilidadeRepositorioMock>();
        }

        [Fact]
        public void DeletarHabilidadeComExito()
        {
            // Arrange
            RepositorioMock.ResetarInstancia();
            int idTeste = 1;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });

            // Act
            _habilidadeRepositorioMock.Deletar(idTeste);

            // Assert
            var habilidadeNaoEncontrada = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.Null(habilidadeNaoEncontrada);
        }

        [Fact]
        public void DeveLancarExcecaoAoDeletarComIdInvalido()
        {
            // Arrange
            int idTeste = 2, idInvalido = 99999;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });

            // Act
            var resultado = Assert.Throws<Exception>(() => _habilidadeRepositorioMock.Deletar(idInvalido));

            // Assert
            Assert.Equal("Habilidade não encontrada.", resultado.Message);
        }
    }
}