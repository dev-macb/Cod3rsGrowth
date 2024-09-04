using System.ComponentModel.DataAnnotations;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Cod3rsGrowth.Tests.RepositoriesMock;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Habilidades
{
    public class TesteServicoAdicionarHabilidade : TesteBase
    {
        private readonly HabilidadeRepositorioMock _habilidadeRepositorioMock;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public TesteServicoAdicionarHabilidade() : base()
        {
            _habilidadeRepositorioMock = _serviceProvider.GetRequiredService<HabilidadeRepositorioMock>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public void AdicionarHabilidadeComExito()
        {
            // Arrange
            var novaHabilidade = new Habilidade
            {
                Id = 1,
                Nome = "Teste",
                Descricao = "Uma descrição qualquer."
            };

            // Act
            _habilidadeRepositorioMock.Adicionar(novaHabilidade);
            var personagemCriado = _habilidades.Find(personagem => personagem.Id == 1);

            // Assert
            Assert.NotNull(personagemCriado);
            Assert.Equivalent(novaHabilidade, personagemCriado);
        }

        [Fact]
        public void DeveLancarExcecaoAoAdicionarComNomeCurto()
        {
            // Arrange
            string nomeCurto = "T";
            var habilidadeInvalida = new Habilidade
            {
                Nome = nomeCurto,
                Descricao = "Uma descrição qualquer."
            };

            // Act - Assert
            var excecao = Assert.Throws<ValidationException>(() => _habilidadeRepositorioMock.Adicionar(habilidadeInvalida));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoAdicionarComNomeGrande()
        {
            // Arrange
            string nomeGrande = "Teste Teste Teste Teste Teste Teste Teste Teste Tes";
            var habilidadeInvalida = new Habilidade
            {
                Nome = nomeGrande,
                Descricao = "Uma descrição qualquer."
            };

            // Act - Assert
            var excecao = Assert.Throws<ValidationException>(() => _habilidadeRepositorioMock.Adicionar(habilidadeInvalida));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoAdicionarComDescricaoGrande()
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
            var excecao = Assert.Throws<ValidationException>(() => _habilidadeRepositorioMock.Adicionar(habilidadeInvalida));
            Assert.Equal("A descrição deve ter no mínimo 0 caracteres e no máximo 200.", excecao.Message);
        }
    }
}