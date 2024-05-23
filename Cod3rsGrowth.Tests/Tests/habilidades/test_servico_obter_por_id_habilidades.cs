using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoObterPorIdHabilidade : TesteBase
    {
        private readonly IHabilidadeServico habilidadeService;

        public TesteServicoObterPorIdHabilidade() : base()
        {
            habilidadeService = ServiceProvider.GetRequiredService<IHabilidadeServico>();
        }

        // [Fact]
        // public void ObterHabilidadePorIdComExito()
        // {
        //     // Arrange
        //     var novoHabilidade = new Habilidade(null, "Ryu", "Ryu");
        //     var idNovoHabilidade = habilidadeService.Criar(novoHabilidade); 

        //     // Act
        //     var personagemEncontrado = habilidadeService.ObterPorId(idNovoHabilidade);

        //     // Assert
        //     Assert.Equivalent(novoHabilidade, personagemEncontrado);
        // }

        // [Fact]
        // public void TentaObterHabilidadeComIdInvalido()
        // {
        //     // Arrange
        //     var idInvalido = 99999;
        //     var novoHabilidade = new Habilidade(null, "Ryu", "Ryu");
        //     var idNovoHabilidade = habilidadeService.Criar(novoHabilidade);

        //     // Act - Assert
        //     var resultado = Assert.Throws<Exception>(() => habilidadeService.ObterPorId(idInvalido));
        //     Assert.Equal("Habilidade não encontrada.", resultado.Message);
        // }
    }
}