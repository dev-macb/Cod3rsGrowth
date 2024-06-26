using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Cod3rsGrowth.Tests.RepositoriesMock;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Habilidades
{
    public class TesteServicoAtualizarHabilidade : TesteBase
    {
        private readonly HabilidadeRepositorioMock _habilidadeRepositorioMock;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public TesteServicoAtualizarHabilidade() : base()
        {
            _habilidadeRepositorioMock = _serviceProvider.GetRequiredService<HabilidadeRepositorioMock>();
        }

        [Fact]
        public void AtualizarHabilidadeComExito()
        {
            // Arrange
            RepositorioMock.ResetarInstancia();
            int idTeste = 1;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });
            var novaHabilidade = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.NotNull(novaHabilidade);

            // Act
            novaHabilidade.Nome = "Testudo";
            novaHabilidade.Descricao = "Uma outra descrição da habilidade";
            _habilidadeRepositorioMock.Atualizar(idTeste, novaHabilidade);

            // Assert
            var personagemAtualizado = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.Equivalent(novaHabilidade, personagemAtualizado);
        }

        [Fact]
        public void DeveLancarExcecaoAoAtualizarComIdInvalido()
        {
            // Arrange
            int idTeste = 2, idInvalido = 99999;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });
            var novaHabilidade = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.NotNull(novaHabilidade);

            // Act - Assert
            novaHabilidade.Nome = "Testudo";
            var resultado = Assert.Throws<Exception>(() => _habilidadeRepositorioMock.Atualizar(idInvalido, novaHabilidade));
            Assert.Equal("Habilidade não encontrada.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoAtualizarComNomeCurto()
        {
            // Arrange
            int idTeste = 3;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });
            var novaHabilidade = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.NotNull(novaHabilidade);

            // Act - Assert
            novaHabilidade.Nome = "T";
            var resultado = Assert.Throws<Exception>(() => _habilidadeRepositorioMock.Atualizar(idTeste, novaHabilidade));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoAtualizarComNomeGrande()
        {
            // Arrange
            int idTeste = 4;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });
            var novaHabilidade = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.NotNull(novaHabilidade);

            // Act - Assert
            novaHabilidade.Nome = "Teste Teste Teste Teste Teste Teste Teste Teste Tes";
            var resultado = Assert.Throws<Exception>(() => _habilidadeRepositorioMock.Atualizar(idTeste, novaHabilidade));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoAtualizarComDescricaoGrande()
        {
            // Arrange
            int idTeste = 5;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });
            var novaHabilidade = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.NotNull(novaHabilidade);

            // Act - Assert
            novaHabilidade.Descricao = "Teste Teste Teste Teste Teste Teste Teste Teste Teste " +
                "Teste Teste Teste Teste Teste Teste Teste Teste Teste Teste Teste " +
                "Teste Teste Teste Teste Teste Teste Teste Teste Teste Teste Teste " +
                "Teste Teste Tes";
            var resultado = Assert.Throws<Exception>(() => _habilidadeRepositorioMock.Atualizar(idTeste, novaHabilidade));
            Assert.Equal("A descrição deve ter no mínimo 0 caracteres e no máximo 200.", resultado.Message);
        }
    }
}