using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Service.Services;
using Cod3rsGrowth.Tests.RepositoriesMock;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Habilidades
{
    public class TesteServicoDeletarHabilidade : TesteBase
    {
        private readonly HabilidadeServico _habilidadeServico;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public TesteServicoDeletarHabilidade() : base()
        {
            _habilidadeServico = _serviceProvider.GetRequiredService<HabilidadeServico>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public async void DeletarHabilidadeComExito()
        {
            // Arrange
            RepositorioMock.ResetarInstancia();
            int idTeste = 8;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste 9", Descricao = "Uma descrição qualquer." });

            // Act
            await _habilidadeServico.Deletar(idTeste);

            // Assert
            var habilidadeNaoEncontrada = _habilidades.Find(h => h.Id == idTeste);
            Assert.Null(habilidadeNaoEncontrada);
        }

        [Fact]
        public async void DeveLancarExcecaoAoDeletarComIdInvalido()
        {
            // Arrange
            int idTeste = 9, idInvalido = 99999;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste 10", Descricao = "Uma descrição qualquer." });

            // Act
            var resultado = await Assert.ThrowsAsync<Exception>(() => _habilidadeServico.Deletar(idInvalido));

            // Assert
            Assert.Equal("Habilidade não encontrada.", resultado.Message);
        }
    }
}