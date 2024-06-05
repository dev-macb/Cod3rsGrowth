using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Personagens
{
    public class TesteServicoRemoverPersonagem : TesteBase
    {
        private readonly PersonagemServico _personagemService;
        private readonly List<Personagem> _personagens = RepositorioMock.ObterInstancia.Personagens;

        public TesteServicoRemoverPersonagem() : base()
        {
            _personagemService = _serviceProvider.GetRequiredService<PersonagemServico>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public void RemoverPersonagemComExito()
        {
            // Arrange
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
            _personagemService.Remover(idTeste);

            // Assert
            var personagemNaoEncontrado = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.Null(personagemNaoEncontrado);
        }

        [Fact]
        public void DeveLancarExcecaoAoRemoverComIdInvalido()
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
            var resultado = Assert.Throws<Exception>(() => _personagemService.Remover(idInvalido));

            // Assert
            Assert.Equal("Personagem não encontrado.", resultado.Message);
        }
    }
}