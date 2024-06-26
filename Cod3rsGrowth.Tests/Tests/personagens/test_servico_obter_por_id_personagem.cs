using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Service.Services;
using Cod3rsGrowth.Tests.RepositoriesMock;

namespace Cod3rsGrowth.Tests.Tests.Personagens
{
    public class TesteServicoObterPorIdPersonagem : TesteBase
    {
        private readonly PersonagemRepositorioMock _personagemRepositorioMock;
        private readonly List<Personagem> _personagens = RepositorioMock.ObterInstancia.Personagens;

        public TesteServicoObterPorIdPersonagem() : base()
        {
            _personagemRepositorioMock = _serviceProvider.GetRequiredService<PersonagemRepositorioMock>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public void ObterPersonagemPorIdComExito()
        {
            // Arrange
            int idTeste = 14;
            var novoPersonagem = new Personagem
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
            _personagens.Add(novoPersonagem);

            // Act
            var personagemAtualizado = _personagens.Find(personagem => personagem.Id == idTeste);

            // Assert
            Assert.Equivalent(novoPersonagem, personagemAtualizado);
        }

        [Fact]
        public void DeveLancarExcecaoAoObterPorIdComIdInvalido()
        {
            // Arrange
            int idTeste = 15, idInvalido = 99999;
            var novoPersonagem = new Personagem
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
            _personagens.Add(novoPersonagem);

            // Act - Assert
            var resultado = Assert.Throws<Exception>(() => _personagemRepositorioMock.ObterPorId(idInvalido));
            Assert.Equal("Personagem não encontrado.", resultado.Message);
        }
    }
}