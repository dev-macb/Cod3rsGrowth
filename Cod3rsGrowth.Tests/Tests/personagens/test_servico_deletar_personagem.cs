using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Service.Services;

namespace Cod3rsGrowth.Tests.Tests.Personagens
{
    public class TesteServicoDeletarPersonagem : TesteBase
    {
        private readonly PersonagemServico _personagemService;
        private readonly List<Personagem> _personagens = RepositorioMock.ObterInstancia.Personagens;

        public TesteServicoDeletarPersonagem() : base()
        {
            _personagemService = _serviceProvider.GetRequiredService<PersonagemServico>();
        }

        [Fact]
        public void DeletarPersonagemComExito()
        {
            // Arrange
            RepositorioMock.ResetarInstancia();
            int idTeste = 16;
            var personagem = new Personagem
            {
                Id = idTeste,
                Nome = "Teste", 
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            };
            _personagens.Add(personagem);
            
            // Act
            _personagemService.Deletar(idTeste);

            // Assert
            var personagemNaoEncontrado = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.Null(personagemNaoEncontrado);
        }

        [Fact]
        public void DeveLancarExcecaoAoDeletarComIdInvalido()
        {
            // Arrange
            int idTeste = 17, idInvalido = 99999;
            var personagem = new Personagem
            {
                Id = idTeste,
                Nome = "Teste", 
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            };
            _personagens.Add(personagem);

            // Act
            var resultado = Assert.Throws<Exception>(() => _personagemService.Deletar(idInvalido));

            // Assert
            Assert.Equal("Personagem não encontrado.", resultado.Message);
        }
    }
}