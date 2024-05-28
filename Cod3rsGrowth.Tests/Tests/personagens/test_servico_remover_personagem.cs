using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoRemoverPersonagem : TesteBase
    {
        private readonly IPersonagemServico _personagemService;

        public TesteServicoRemoverPersonagem() : base()
        {
            _personagemService = ServiceProvider.GetRequiredService<IPersonagemServico>();
        }

        [Fact]
        public void RemoverPersonagemComExito()
        {
            // Arrange
            var personagem = new Personagem
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
            int idNovoPersonagem = _personagemService.Criar(personagem);
            
            // Act
            _personagemService.Remover(idNovoPersonagem);

            // Assert
            var excecao = Assert.Throws<Exception>(() => _personagemService.ObterPorId(idNovoPersonagem));
            Assert.Equal("Personagem não encontrado.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoRemoverComIdInvalido()
        {
            // Arrange
            int idInvalido = 99999;
            var personagem = new Personagem
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
            int idNovoPersonagem = _personagemService.Criar(personagem);

            // Act
            var resultado = Assert.Throws<Exception>(() => _personagemService.Remover(idInvalido));

            // Assert
            Assert.Equal("Personagem não encontrado.", resultado.Message);
        }
    }
}