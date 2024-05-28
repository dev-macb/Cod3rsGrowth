using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoEditarPersonagem : TesteBase
    {
        private readonly IPersonagemServico _personagemService;

        public TesteServicoEditarPersonagem() : base()
        {
            _personagemService = ServiceProvider.GetRequiredService<IPersonagemServico>();
        }

        [Fact]
        public void EditarPersonagemComExito()
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
            var novoPersonagem = _personagemService.ObterPorId(idNovoPersonagem);

            // Act
            novoPersonagem.Nome = "Testudo";
            novoPersonagem.Vida = 10;
            novoPersonagem.Energia = 5;
            novoPersonagem.Velocidade = 0.5;
            novoPersonagem.Forca = CategoriasEnum.Fraco;
            novoPersonagem.Inteligencia = CategoriasEnum.Fraco;
            _personagemService.Editar(idNovoPersonagem, novoPersonagem);

            // Assert
            var personagemAtualizado = _personagemService.ObterPorId(idNovoPersonagem);
            Assert.Equivalent(novoPersonagem, personagemAtualizado);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComIdInvalido()
        {
            // Arrange
            var idInvalido = 99999;
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
            var novoPersonagem = _personagemService.ObterPorId(idNovoPersonagem);

            // Act - Assert
            novoPersonagem.Nome = "Testudo";
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idInvalido, novoPersonagem));
            Assert.Equal("Personagem não encontrado.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComNomeCurto()
        {
            // Arrange
            var personagemOriginal = new Personagem
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
            int idNovoPersonagem = _personagemService.Criar(personagemOriginal);
            var novoPersonagem = _personagemService.ObterPorId(idNovoPersonagem);

            // Act - Assert
            novoPersonagem.Nome = "T";
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idNovoPersonagem, novoPersonagem));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComNomeGrande()
        {
            // Arrange
            var personagemOriginal = new Personagem
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
            int idNovoPersonagem = _personagemService.Criar(personagemOriginal);
            var novoPersonagem = _personagemService.ObterPorId(idNovoPersonagem);

            // Act - Assert
            novoPersonagem.Nome = "Um nome qualquer que seja grande o suficiente para ser inutil";
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idNovoPersonagem, novoPersonagem));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComVidaMenorQueZero()
        {
            // Arrange
            var personagemOriginal = new Personagem
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
            int idNovoPersonagem = _personagemService.Criar(personagemOriginal);
            var novoPersonagem = _personagemService.ObterPorId(idNovoPersonagem);

            // Act - Assert
            novoPersonagem.Vida = -1;
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idNovoPersonagem, novoPersonagem));
            Assert.Equal("A vida deve estar entre 0 e 100.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComVidaMaiorQueCem()
        {
            // Arrange
            var personagemOriginal = new Personagem
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
            int idNovoPersonagem = _personagemService.Criar(personagemOriginal);
            var novoPersonagem = _personagemService.ObterPorId(idNovoPersonagem);

            // Act - Assert
            novoPersonagem.Vida = 101;
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idNovoPersonagem, novoPersonagem));
            Assert.Equal("A vida deve estar entre 0 e 100.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComEnergiaMenorQueZero()
        {
            // Arrange
            var personagemOriginal = new Personagem
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
            int idNovoPersonagem = _personagemService.Criar(personagemOriginal);
            var novoPersonagem = _personagemService.ObterPorId(idNovoPersonagem);

            // Act - Assert
            novoPersonagem.Energia = -1;
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idNovoPersonagem, novoPersonagem));
            Assert.Equal("A energia deve estar entre 0 e 50.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComEnergiaMaiorQueCinquenta()
        {
            // Arrange
            var personagemOriginal = new Personagem
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
            int idNovoPersonagem = _personagemService.Criar(personagemOriginal);
            var novoPersonagem = _personagemService.ObterPorId(idNovoPersonagem);

            // Act - Assert
            novoPersonagem.Energia = 51;
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idNovoPersonagem, novoPersonagem));
            Assert.Equal("A energia deve estar entre 0 e 50.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComVelocidadeMenorQueZero()
        {
            // Arrange
            var personagemOriginal = new Personagem
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
            int idNovoPersonagem = _personagemService.Criar(personagemOriginal);
            var novoPersonagem = _personagemService.ObterPorId(idNovoPersonagem);

            // Act - Assert
            novoPersonagem.Velocidade = -1;
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idNovoPersonagem, novoPersonagem));
            Assert.Equal("A velocidade deve estar entre 0 e 2.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoEditarComVelocidadeMaiorQueDois()
        {
            // Arrange
            var personagemOriginal = new Personagem
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
            int idNovoPersonagem = _personagemService.Criar(personagemOriginal);
            var novoPersonagem = _personagemService.ObterPorId(idNovoPersonagem);

            // Act - Assert
            novoPersonagem.Velocidade = 2.1;
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idNovoPersonagem, novoPersonagem));
            Assert.Equal("A velocidade deve estar entre 0 e 2.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoCriarComForcaInvalida()
        {
            // Arrange
            var personagemOriginal = new Personagem
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
            int idNovoPersonagem = _personagemService.Criar(personagemOriginal);
            var novoPersonagem = _personagemService.ObterPorId(idNovoPersonagem);

            // Act - Assert
            novoPersonagem.Forca = (CategoriasEnum)99999;
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idNovoPersonagem, novoPersonagem));
            Assert.Equal("A força deve ser um valor válido de CategoriasEnum.", resultado.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoCriarComInteligenciaInvalida()
        {
            // Arrange
            var personagemOriginal = new Personagem
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
            int idNovoPersonagem = _personagemService.Criar(personagemOriginal);
            var novoPersonagem = _personagemService.ObterPorId(idNovoPersonagem);

            // Act - Assert
            novoPersonagem.Inteligencia = (CategoriasEnum)99999;;
            var resultado = Assert.Throws<Exception>(() => _personagemService.Editar(idNovoPersonagem, novoPersonagem));
            Assert.Equal("A inteligência deve ser um valor válido de CategoriasEnum.", resultado.Message);
        }
    }
}