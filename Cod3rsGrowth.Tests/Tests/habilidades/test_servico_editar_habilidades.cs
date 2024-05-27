using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoEditarHabilidade : TesteBase
    {
        private readonly IHabilidadeServico _habilidadeService;

        public TesteServicoEditarHabilidade() : base()
        {
            _habilidadeService = ServiceProvider.GetRequiredService<IHabilidadeServico>();
        }

        [Fact]
        public void EditarHabilidadeComExito()
        {
            // Arrange
            var habilidade = new Habilidade(null, "Teste", "Uma descrição qualquer");
            int idNovaHabilidade = _habilidadeService.Criar(habilidade);
            var novaHabilidade = _habilidadeService.ObterPorId(idNovaHabilidade);

            // Act
            novaHabilidade.Nome = "Testudo";
            novaHabilidade.Descricao = "Uma outra descrição da habilidade";
            _habilidadeService.Editar(idNovaHabilidade, novaHabilidade);

            // Assert
            var personagemAtualizado = _habilidadeService.ObterPorId(idNovaHabilidade);
            Assert.Equivalent(novaHabilidade, personagemAtualizado);
        }

        [Fact]
        public void TentarEditarHabilidadeComIdInvalido()
        {
            // Arrange
            var idInvalido = 99999;
            var personagem = new Habilidade(null, "Teste", "Uma descrição qualquer");
            int idNovaHabilidade = _habilidadeService.Criar(personagem);
            var novaHabilidade = _habilidadeService.ObterPorId(idNovaHabilidade);

            // Act - Assert
            novaHabilidade.Nome = "Testudo";
            var resultado = Assert.Throws<Exception>(() => _habilidadeService.Editar(idInvalido, novaHabilidade));
            Assert.Equal("Habilidade não encontrada.", resultado.Message);
        }

        [Fact]
        public void EditarHabilidadeComNomeCurto()
        {
            // Arrange
            var habilidade = new Habilidade(null, "Teste", "Uma descrição qualquer");
            int idNovaHabilidade = _habilidadeService.Criar(habilidade);
            var novaHabilidade = _habilidadeService.ObterPorId(idNovaHabilidade);

            // Act - Assert
            novaHabilidade.Nome = "T";
            var resultado = Assert.Throws<Exception>(() => _habilidadeService.Editar(idNovaHabilidade, novaHabilidade));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", resultado.Message);
        }

        [Fact]
        public void EditarHabilidadeComNomeGrande()
        {
            // Arrange
            var habilidade = new Habilidade(null, "Teste", "Uma descrição qualquer");
            int idNovaHabilidade = _habilidadeService.Criar(habilidade);
            var novaHabilidade = _habilidadeService.ObterPorId(idNovaHabilidade);

            // Act - Assert
            novaHabilidade.Nome = "Teste Teste Teste Teste Teste Teste Teste Teste Tes";
            var resultado = Assert.Throws<Exception>(() => _habilidadeService.Editar(idNovaHabilidade, novaHabilidade));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", resultado.Message);
        }

        [Fact]
        public void EditarHabilidadeComDescricaoGrande()
        {
            // Arrange
            var habilidade = new Habilidade(null, "Teste", "Uma descrição qualquer");
            int idNovaHabilidade = _habilidadeService.Criar(habilidade);
            var novaHabilidade = _habilidadeService.ObterPorId(idNovaHabilidade);

            // Act - Assert
            novaHabilidade.Descricao = "Teste Teste Teste Teste Teste Teste Teste Teste Teste " +
                "Teste Teste Teste Teste Teste Teste Teste Teste Teste Teste Teste " + 
                "Teste Teste Teste Teste Teste Teste Teste Teste Teste Teste Teste " +
                "Teste Teste Tes";
            var resultado = Assert.Throws<Exception>(() => _habilidadeService.Editar(idNovaHabilidade, novaHabilidade));
            Assert.Equal("A descrição deve ter no mínimo 0 caracteres e no máximo 200.", resultado.Message);
        }
    }
}