using FluentValidation;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Service.Services;
using Cod3rsGrowth.Tests.RepositoriesMock;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Habilidades
{
    public class TesteServicoAdicionarHabilidade : TesteBase
    {
        private readonly HabilidadeServico _habilidadeServico;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public TesteServicoAdicionarHabilidade() : base()
        {
            _habilidadeServico = _serviceProvider.GetRequiredService<HabilidadeServico>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public async void AdicionarHabilidadeComExito()
        {
            // Arrange
            var novaHabilidade = new Habilidade
            {
                Nome = "Teste 1",
                Descricao = "Uma descrição qualquer."
            };

            // Act
            var resultado = await _habilidadeServico.Adicionar(novaHabilidade);
            var personagemCriado = _habilidades.Find(personagem => personagem.Id == resultado);

            // Assert
            Assert.NotNull(personagemCriado);
            Assert.Equivalent(novaHabilidade, personagemCriado);
        }

        [Fact]
        public async Task DeveLancarExcecaoAoAdicionarHabilidadeComNomeCurto()
        {
            // Arrange
            string nomeCurto = "T";
            var habilidadeInvalida = new Habilidade
            {
                Nome = nomeCurto,
                Descricao = "Uma descrição qualquer."
            };

            // Act - Assert
            var excecao = await Assert.ThrowsAsync<ValidationException>(async () => await _habilidadeServico.Adicionar(habilidadeInvalida));
            Assert.Contains("O nome deve ter no mínimo 3 caracteres e no máximo 50.", excecao.Message);
        }

        [Fact]
        public async void DeveLancarExcecaoAoAdicionarHabilidadeComNomeGrande()
        {
            // Arrange
            string nomeGrande = "Teste Teste Teste Teste Teste Teste Teste Teste Tes";
            var habilidadeInvalida = new Habilidade
            {
                Nome = nomeGrande,
                Descricao = "Uma descrição qualquer."
            };

            // Act - Assert
            var excecao = await Assert.ThrowsAsync<ValidationException>(async () => await _habilidadeServico.Adicionar(habilidadeInvalida));
            Assert.Contains("O nome deve ter no mínimo 3 caracteres e no máximo 50.", excecao.Message);
        }

        [Fact]
        public async void DeveLancarExcecaoAoAdicionarHabilidadeComDescricaoGrande()
        {
            // Arrange
            string descricaoGrande = "Teste Teste Teste Teste Teste Teste Teste Teste Teste " +
                "Teste Teste Teste Teste Teste Teste Teste Teste Teste " +
                "Teste Teste Teste Teste Teste Teste Teste Teste Teste " +
                "Teste Teste Teste Teste Teste Teste Tes";
            var habilidadeInvalida = new Habilidade
            {
                Nome = "Teste",
                Descricao = descricaoGrande
            };


            // Act - Assert
            var excecao = await Assert.ThrowsAsync<ValidationException>(async () => await _habilidadeServico.Adicionar(habilidadeInvalida));
            Assert.Contains("A descrição deve ter no mínimo 0 caracteres e no máximo 200.", excecao.Message);
        }
    }
}