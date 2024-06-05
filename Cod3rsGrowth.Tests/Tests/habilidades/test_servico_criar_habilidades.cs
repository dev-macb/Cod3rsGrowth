using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Habilidades
{
    public class TesteServicoCriarHabilidade : TesteBase
    {
        private readonly HabilidadeServico _habilidadeService;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public TesteServicoCriarHabilidade() : base()
        {
            _habilidadeService = _serviceProvider.GetRequiredService<HabilidadeServico>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public void CriarHabilidadeComExito()
        {
            // Arrange
            var novaHabilidade = new Habilidade 
            {
                Id = 1,
                Nome = "Teste", 
                Descricao = "Uma descrição qualquer."
            };

            // Act
            _habilidadeService.Criar(novaHabilidade);
            var personagemCriado = _habilidades.Find(personagem => personagem.Id == 1);

            // Assert
            Assert.NotNull(personagemCriado);
            Assert.Equivalent(novaHabilidade, personagemCriado);
        }

        [Fact]
        public void DeveLancarExcecaoAoCriarComNomeCurto()
        {
            // Arrange
            string nomeCurto = "T";
            var habilidadeInvalida = new Habilidade 
            { 
                Nome = nomeCurto, 
                Descricao = "Uma descrição qualquer."
            };

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _habilidadeService.Criar(habilidadeInvalida));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoCriarComNomeGrande()
        {
            // Arrange
            string nomeGrande = "Teste Teste Teste Teste Teste Teste Teste Teste Tes";
            var habilidadeInvalida = new Habilidade 
            { 
                Nome = nomeGrande, 
                Descricao = "Uma descrição qualquer." 
            };

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _habilidadeService.Criar(habilidadeInvalida));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoCriarComDescricaoGrande()
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
            var excecao = Assert.Throws<Exception>(() => _habilidadeService.Criar(habilidadeInvalida));
            Assert.Equal("A descrição deve ter no mínimo 0 caracteres e no máximo 200.", excecao.Message);
        }
    }
}