using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Habilidades
{
    public class TesteServicoObterPorIdHabilidade : TesteBase
    {
        private readonly HabilidadeServico habilidadeService;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public TesteServicoObterPorIdHabilidade() : base()
        {
            habilidadeService = _serviceProvider.GetRequiredService<HabilidadeServico>();
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
            var personagemEncontrado = habilidadeService.ObterPorId(idTeste);

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
            var resultado = Assert.Throws<Exception>(() => habilidadeService.ObterPorId(idInvalido));
            Assert.Equal("Habilidade não encontrada.", resultado.Message);
        }
    }
}