using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoRemoverHabilidade : TesteBase
    {
        private readonly HabilidadeServico _habilidadeService;
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;    

        public TesteServicoRemoverHabilidade() : base()
        {
            _habilidadeService = ServiceProvider.GetRequiredService<HabilidadeServico>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public void RemoverHabilidadeComExito()
        {
            // Arrange
            int idTeste = 1;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });
            
            // Act
            _habilidadeService.Remover(idTeste);

            // Assert
            var habilidadeNaoEncontrada = _habilidades.Find(habilidade => habilidade.Id == idTeste);
            Assert.Null(habilidadeNaoEncontrada);
        }

        [Fact]
        public void DeveLancarExcecaoAoRemoverComIdInvalido()
        {
            // Arrange
            int idTeste = 2, idInvalido = 99999;
            _habilidades.Add(new Habilidade { Id = idTeste, Nome = "Teste", Descricao = "Uma descrição qualquer." });
            
            // Act
            var resultado = Assert.Throws<Exception>(() => _habilidadeService.Remover(idInvalido));

            // Assert
            Assert.Equal("Habilidade não encontrada.", resultado.Message);
        }
    }
}