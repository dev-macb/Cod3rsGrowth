using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Service.Services;
using Cod3rsGrowth.Tests.RepositoriesMock;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Habilidades
{
    public class TesteServicoObterPorIdHabilidade : TesteBase
    {
        private readonly HabilidadeServico _habilidadeServico;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public TesteServicoObterPorIdHabilidade() : base()
        {
            _habilidadeServico = _serviceProvider.GetRequiredService<HabilidadeServico>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public async void ObtemHabilidadePorIdComExito()
        {
            // Arrange
            int idTeste = 6;
            var novaHabilidade = new Habilidade { Id = idTeste, Nome = "Teste 7", Descricao = "Uma descrição qualquer." };
            _habilidades.Add(novaHabilidade);

            // Act
            var personagemEncontrado = await _habilidadeServico.ObterPorId(idTeste);

            // Assert
            Assert.Equivalent(novaHabilidade, personagemEncontrado);
        }

        [Fact]
        public async void DeveLancarExcecaoAoBuscarPorIdComIdInvalido()
        {
            // Arrange
            int idTeste = 7, idInvalido = 99999;
            var novaHabilidade = new Habilidade { Id = idTeste, Nome = "Teste 8", Descricao = "Uma descrição qualquer." };
            _habilidades.Add(novaHabilidade);

            // Act - Assert
            var resultado = await Assert.ThrowsAsync<Exception>(() => _habilidadeServico.ObterPorId(idInvalido));
            Assert.Equal("Habilidade não encontrada.", resultado.Message);
        }
    }
}