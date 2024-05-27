using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoCriarHabilidade : TesteBase
    {
        private readonly IHabilidadeServico _habilidadeService;

        public TesteServicoCriarHabilidade() : base()
        {
            _habilidadeService = ServiceProvider.GetRequiredService<IHabilidadeServico>();
        }

        [Fact]
        public void CriarHabilidadeComExito()
        {
            // Arrange
            var novoHabilidade = new Habilidade(null, "Teste da Silva", "Uma descrição qualquer");

            // Act
            var resultado = _habilidadeService.Criar(novoHabilidade);
            var personagemCriado = _habilidadeService.ObterPorId(resultado);

            // Assert
            Assert.NotNull(personagemCriado);
            Assert.Equal(personagemCriado.Id, resultado);
            Assert.Equal(novoHabilidade.Nome, personagemCriado.Nome);
        }

        [Fact]
        public void DeveLancarExcecaoAoCriarComNomeCurto()
        {
            // Arrange
            string nomeCurto = "T";
            var habilidadeInvalida = new Habilidade(null, nomeCurto, "Uma descrição qualquer");

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _habilidadeService.Criar(habilidadeInvalida));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoCriarComNomeGrande()
        {
            // Arrange
            string nomeGrande = "Teste Teste Teste Teste Teste Teste Teste Teste Tes";
            var habilidadeInvalida = new Habilidade(null, nomeGrande, "Uma descrição qualquer");

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _habilidadeService.Criar(habilidadeInvalida));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoCriarComDescricaoGrande()
        {
            // Arrange
            string descricaoGrande = "Teste Teste Teste Teste Teste Teste Teste Teste Teste " +
                "Teste Teste Teste Teste Teste Teste Teste Teste Teste Teste Teste " + 
                "Teste Teste Teste Teste Teste Teste Teste Teste Teste Teste Teste " +
                "Teste Teste Tes";
            var habilidadeInvalida = new Habilidade(null, "Teste", descricaoGrande);

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _habilidadeService.Criar(habilidadeInvalida));
            Assert.Equal("A descrição deve ter no mínimo 0 caracteres e no máximo 200.", excecao.Message);
        }
    }
}