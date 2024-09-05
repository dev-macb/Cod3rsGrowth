using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Service.Services;
using Cod3rsGrowth.Tests.RepositoriesMock;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Personagens
{
    public class TesteServicoDeletarPersonagem : TesteBase
    {
        private readonly PersonagemServico _personagemServico;
        private readonly List<Personagem> _personagens = RepositorioMock.ObterInstancia.Personagens;

        public TesteServicoDeletarPersonagem() : base()
        {
            _personagemServico = _serviceProvider.GetRequiredService<PersonagemServico>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public async void DeletarPersonagemComExito()
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
            await _personagemServico.Deletar(idTeste);

            // Assert
            var personagemNaoEncontrado = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.Null(personagemNaoEncontrado);
        }

        [Fact]
        public async void DeveLancarExcecaoAoDeletarComIdInvalido()
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
            var resultado = await Assert.ThrowsAsync<Exception>(() => _personagemServico.Deletar(idInvalido));

            // Assert
            Assert.Equal("Personagem não encontrado.", resultado.Message);
        }
    }
}