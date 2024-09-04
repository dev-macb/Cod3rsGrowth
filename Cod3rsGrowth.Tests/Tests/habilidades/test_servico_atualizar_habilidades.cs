using FluentValidation;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Service.Services;
using Cod3rsGrowth.Tests.RepositoriesMock;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Habilidades
{
    public class TesteServicoAtualizarHabilidade : TesteBase
    {
        private readonly HabilidadeServico _habilidadeServico;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public TesteServicoAtualizarHabilidade() : base()
        {
            _habilidadeServico = _serviceProvider.GetRequiredService<HabilidadeServico>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public async void AtualizarHabilidadeComExito()
        {
            // Arrange
            int idTeste = 1;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });
            var novaHabilidade = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.NotNull(novaHabilidade);

            // Act
            novaHabilidade.Nome = "Testudo";
            novaHabilidade.Descricao = "Uma outra descrição da habilidade";
            await _habilidadeServico.Atualizar(idTeste, novaHabilidade);

            // Assert
            var personagemAtualizado = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.Equivalent(novaHabilidade, personagemAtualizado);
        }

        [Fact]
        public async void DeveLancarExcecaoAoAtualizarComIdInvalido()
        {
            // Arrange
            RepositorioMock.ResetarInstancia();
            int idTeste = 2, idInvalido = 9999;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });
            var novaHabilidade = _habilidades.Find(h => h.Id == idTeste);
            Assert.NotNull(novaHabilidade);

            // Act
            novaHabilidade.Nome = "Testudo";

            // Act - Assert
            var resultado = await Assert.ThrowsAsync<Exception>(() => _habilidadeServico.Atualizar(idInvalido, novaHabilidade));
            Assert.Contains("Habilidade não encontrada.", resultado.Message);
        }

        [Fact]
        public async void DeveLancarExcecaoAoAtualizarComNomeCurto()
        {
            // Arrange
            int idTeste = 3;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });
            var novaHabilidade = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.NotNull(novaHabilidade);

            // Act - Assert
            novaHabilidade.Nome = "T";
            var resultado = await Assert.ThrowsAsync<ValidationException>(() => _habilidadeServico.Atualizar(idTeste, novaHabilidade));
            Assert.Contains("O nome deve ter no mínimo 3 caracteres e no máximo 50.", resultado.Message);
        }

        [Fact]
        public async void DeveLancarExcecaoAoAtualizarComNomeGrande()
        {
            // Arrange
            int idTeste = 4;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });
            var novaHabilidade = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.NotNull(novaHabilidade);

            // Act - Assert
            novaHabilidade.Nome = "Teste Teste Teste Teste Teste Teste Teste Teste Tes";
            var resultado = await Assert.ThrowsAsync<ValidationException>(() => _habilidadeServico.Atualizar(idTeste, novaHabilidade));
            Assert.Contains("O nome deve ter no mínimo 3 caracteres e no máximo 50.", resultado.Message);
        }

        [Fact]
        public async void DeveLancarExcecaoAoAtualizarComDescricaoGrande()
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
            var resultado = await Assert.ThrowsAsync<ValidationException>(() => _habilidadeServico.Atualizar(idTeste, novaHabilidade));
            Assert.Contains("A descrição deve ter no mínimo 0 caracteres e no máximo 200.", resultado.Message);
        }
    }
}