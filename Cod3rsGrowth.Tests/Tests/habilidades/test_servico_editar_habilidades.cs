using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Habilidades
{
    public class TesteServicoEditarHabilidade : TesteBase
    {
        private readonly HabilidadeServico _habilidadeService;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;    

        public TesteServicoEditarHabilidade() : base()
        {
            _habilidadeService = _serviceProvider.GetRequiredService<HabilidadeServico>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public void EditarHabilidadeComExito()
        {
            // Arrange
            int idTeste = 1;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });
            var novaHabilidade = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.NotNull(novaHabilidade);

            // Act
            novaHabilidade.Nome = "Testudo";
            novaHabilidade.Descricao = "Uma outra descrição da habilidade";
            _habilidadeService.Editar(idTeste, novaHabilidade);

            // Assert
            var personagemAtualizado = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.Equivalent(novaHabilidade, personagemAtualizado);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComIdInvalido()
        {
            // Arrange
            int idTeste = 2, idInvalido = 99999;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });
            var novaHabilidade = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.NotNull(novaHabilidade);

            // Act - Assert
            novaHabilidade.Nome = "Testudo";
            var resultado = Assert.Throws<Exception>(() => _habilidadeService.Editar(idInvalido, novaHabilidade));
            Assert.Equal("Habilidade não encontrada.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComNomeCurto()
        {
            // Arrange
            int idTeste = 3;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });
            var novaHabilidade = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.NotNull(novaHabilidade);

            // Act - Assert
            novaHabilidade.Nome = "T";
            var resultado = Assert.Throws<Exception>(() => _habilidadeService.Editar(idTeste, novaHabilidade));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComNomeGrande()
        {
            // Arrange
            int idTeste = 4;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });
            var novaHabilidade = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.NotNull(novaHabilidade);

            // Act - Assert
            novaHabilidade.Nome = "Teste Teste Teste Teste Teste Teste Teste Teste Tes";
            var resultado = Assert.Throws<Exception>(() => _habilidadeService.Editar(idTeste, novaHabilidade));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComDescricaoGrande()
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
            var resultado = Assert.Throws<Exception>(() => _habilidadeService.Editar(idTeste, novaHabilidade));
            Assert.Equal("A descrição deve ter no mínimo 0 caracteres e no máximo 200.", resultado.Message);
        }
    }
}