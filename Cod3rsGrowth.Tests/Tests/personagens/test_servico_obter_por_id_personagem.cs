using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoObterPorIdPersonagem : TesteBase
    {
        private readonly PersonagemServico _personagemService;
        private readonly List<Personagem> _personagens = RepositorioMock.ObterInstancia.Personagens;

        public TesteServicoObterPorIdPersonagem() : base()
        {
            _personagemService = ServiceProvider.GetRequiredService<PersonagemServico>();
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
            var resultado = Assert.Throws<Exception>(() => _personagemService.ObterPorId(idInvalido));
            Assert.Equal("Personagem não encontrado.", resultado.Message);
        }
    }
}