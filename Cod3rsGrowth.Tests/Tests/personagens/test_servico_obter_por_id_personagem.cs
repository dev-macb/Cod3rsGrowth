using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoObterPorIdPersonagem : TesteBase
    {
        private readonly IPersonagemServico _personagemService;

        public TesteServicoObterPorIdPersonagem() : base()
        {
            _personagemService = ServiceProvider.GetRequiredService<IPersonagemServico>();
        }

        [Fact]
        public void ObterPersonagemPorIdComExito()
        {
            // Arrange
            var novoPersonagem = new Personagem
            {
                Nome = "Teste", 
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            };
            int idNovoPersonagem = _personagemService.Criar(novoPersonagem);

            // Act
            var personagemEncontrado = _personagemService.ObterPorId(idNovoPersonagem);

            // Assert
            Assert.Equivalent(novoPersonagem, personagemEncontrado);
        }

        [Fact]
        public void DeveLancarExcecaoAoObterPorIdComIdInvalido()
        {
            // Arrange
            var idInvalido = 99999;
            var novoPersonagem = new Personagem
            {
                Nome = "Teste", 
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            };
            var idNovoPersonagem = _personagemService.Criar(novoPersonagem);

            // Act - Assert
            var resultado = Assert.Throws<Exception>(() => _personagemService.ObterPorId(idInvalido));
            Assert.Equal("Personagem não encontrado.", resultado.Message);
        }
    }
}