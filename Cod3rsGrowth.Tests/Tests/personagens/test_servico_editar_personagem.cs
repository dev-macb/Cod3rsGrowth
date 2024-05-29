using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoEditarPersonagem : TesteBase
    {
        private readonly PersonagemServico _personagemService;
        private readonly List<Personagem> _personagens = RepositorioMock.ObterInstancia.Personagens;

        public TesteServicoEditarPersonagem() : base()
        {
            _personagemService = ServiceProvider.GetRequiredService<PersonagemServico>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public void EditarPersonagemComExito()
        {
            // Arrange
            int idTeste = 2;
            _personagens.Add(new Personagem
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
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act
            novoPersonagem.Nome = "Testudo";
            novoPersonagem.Vida = 10;
            novoPersonagem.Energia = 5;
            novoPersonagem.Velocidade = 0.5;
            novoPersonagem.Forca = CategoriasEnum.Fraco;
            novoPersonagem.Inteligencia = CategoriasEnum.Fraco;
            _personagemService.Editar(idTeste, novoPersonagem);

            // Assert
            var personagemAtualizado = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.Equivalent(novoPersonagem, personagemAtualizado);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComIdInvalido()
        {
            // Arrange
            int idTeste = 3, idInvalido = 99999;
            _personagens.Add(new Personagem
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
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Nome = "Testudo";
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idInvalido, novoPersonagem));
            Assert.Equal("Personagem não encontrado.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComNomeCurto()
        {
            // Arrange
            int idTeste = 4;
            _personagens.Add(new Personagem
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
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Nome = "T";
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idTeste, novoPersonagem));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComNomeGrande()
        {
            // Arrange
            int idTeste = 5;
            _personagens.Add(new Personagem
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
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Nome = "Um nome qualquer que seja grande o suficiente para ser inutil";
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idTeste, novoPersonagem));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComVidaMenorQueZero()
        {
            // Arrange
            int idTeste = 6;
            _personagens.Add(new Personagem
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
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Vida = -1;
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idTeste, novoPersonagem));
            Assert.Equal("A vida deve estar entre 0 e 100.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComVidaMaiorQueCem()
        {
            // Arrange
            int idTeste = 7;
            _personagens.Add(new Personagem
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
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Vida = 101;
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idTeste, novoPersonagem));
            Assert.Equal("A vida deve estar entre 0 e 100.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComEnergiaMenorQueZero()
        {
            // Arrange
            int idTeste = 8;
            _personagens.Add(new Personagem
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
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Energia = -1;
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idTeste, novoPersonagem));
            Assert.Equal("A energia deve estar entre 0 e 50.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComEnergiaMaiorQueCinquenta()
        {
            // Arrange
            int idTeste = 9;
            _personagens.Add(new Personagem
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
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Energia = 51;
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idTeste, novoPersonagem));
            Assert.Equal("A energia deve estar entre 0 e 50.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComVelocidadeMenorQueZero()
        {
            // Arrange
            int idTeste = 10;
            _personagens.Add(new Personagem
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
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Velocidade = -1;
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idTeste, novoPersonagem));
            Assert.Equal("A velocidade deve estar entre 0 e 2.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComVelocidadeMaiorQueDois()
        {
            // Arrange
            int idTeste = 11;
            _personagens.Add(new Personagem
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
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Velocidade = 2.1;
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idTeste, novoPersonagem));
            Assert.Equal("A velocidade deve estar entre 0 e 2.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoCriarComForcaInvalida()
        {
            // Arrange
            int idTeste = 12;
            _personagens.Add(new Personagem
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
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Forca = (CategoriasEnum)99999;
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idTeste, novoPersonagem));
            Assert.Equal("A força deve ser um valor válido de CategoriasEnum.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoCriarComInteligenciaInvalida()
        {
            // Arrange
            int idTeste = 13;
            _personagens.Add(new Personagem
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
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Inteligencia = (CategoriasEnum)99999;;
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idTeste, novoPersonagem));
            Assert.Equal("A inteligência deve ser um valor válido de CategoriasEnum.", resultado.Message);
        }
    }
}