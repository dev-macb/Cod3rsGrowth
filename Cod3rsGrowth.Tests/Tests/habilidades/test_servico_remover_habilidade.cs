using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoRemoverHabilidade : TesteBase
    {
        private readonly IHabilidadeServico _habilidadeService;

        public TesteServicoRemoverHabilidade() : base()
        {
            _habilidadeService = ServiceProvider.GetRequiredService<IHabilidadeServico>();
        }

        [Fact]
        public void RemoverHabilidadeComExito()
        {
            // Arrange
            int idNovoHabilidade = _habilidadeService.Criar(new Habilidade(null, "Teste", "Uma descição qualquer"));
            
            // Act
            _habilidadeService.Remover(idNovoHabilidade);

            // Assert
            var excecao = Assert.Throws<Exception>(() => _habilidadeService.ObterPorId(idNovoHabilidade));
            Assert.Equal("Habilidade não encontrada.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoRemoverComIdInvalido()
        {
            // Arrange
            int idInvalido = 99999;
            int idNovoHabilidade = _habilidadeService.Criar(new Habilidade(null, "Teste", "Uma descição qualquer"));

            // Act
            var resultado = Assert.Throws<Exception>(() => _habilidadeService.Remover(idInvalido));

            // Assert
            Assert.Equal("Habilidade não encontrada.", resultado.Message);
        }
    }
}